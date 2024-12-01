import React, { useState, useEffect } from "react";
import { getCivilizations, createCivilization } from "../services/api";

const CivilizationList = ({ onSelect, updatedCivilization }) => {
  const [civilizations, setCivilizations] = useState([]);
  const [selectedId, setSelectedId] = useState(null);
  const [error, setError] = useState(null);
  const [showForm, setShowForm] = useState(false);
  const [newCiv, setNewCiv] = useState({
    name: "",
    population: "",
  });

  useEffect(() => {
    const fetchCivilizations = async () => {
      try {
        const data = await getCivilizations();
        setCivilizations(data);
      } catch (err) {
        setError("Failed to fetch civilizations.");
        console.error(err.message);
      }
    };

    fetchCivilizations();
  }, []);

  useEffect(() => {
    if (updatedCivilization) {
      setCivilizations((prev) =>
        prev.map((civ) =>
          civ.id === updatedCivilization.id ? updatedCivilization : civ
        )
      );
    }
  }, [updatedCivilization]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewCiv({ ...newCiv, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const createdCiv = await createCivilization(newCiv);
      setCivilizations((prev) => [...prev, createdCiv]);
      setShowForm(false);
      setNewCiv({ name: "", population: "" });
    } catch (err) {
      setError("Failed to create civilization.");
      console.error(err.message);
    }
  };

  const handleSelect = (id) => {
    setSelectedId(id);
    onSelect(id);
  };

  if (error) return <p>{error}</p>;
  if (!civilizations.length) return <p>Loading civilizations...</p>;

  // Find the min and max populations to normalize sizes
  const populations = civilizations.map((civ) => civ.population);
  let minPopulation = Math.min(...populations);
  let maxPopulation = Math.max(...populations);

  const getFontSize = (population) => {
    if (population <= 0) return null;
    const minSize = 12; // Smallest font size (px)
    const maxSize = 36; // Largest font size (px)
    return (
      ((population - minPopulation) / (maxPopulation - minPopulation)) *
        (maxSize - minSize) +
      minSize
    );
  };

  const getHue = (population) => {
    if (population <= 0) return null;
    return (population / maxPopulation) * 120; // From green to red
  };

  return (
    <div className="sidebar">
      <div className="civilization-list">
        {civilizations.map((civ) => (
          <span
            key={civ.id}
            onClick={() => handleSelect(civ.id)}
            style={{
              fontSize:
                civ.population > 0
                  ? `${getFontSize(civ.population)}px`
                  : undefined,
              color:
                civ.population > 0
                  ? `hsl(${getHue(civ.population)}, 70%, 50%)`
                  : "#777",
              transition: "font-size 0.5s ease, color 0.5s ease",
            }}
            className={`civilization-tag ${
              selectedId === civ.id ? "selected" : ""
            } ${civ.population <= 0 ? "crossed-out" : ""}`}
          >
            {civ.name}
          </span>
        ))}
      </div>
      <div>
        <button onClick={() => setShowForm((prev) => !prev)}>
          {showForm ? "Cancel" : "Add Civilization"}
        </button>
        {showForm && (
          <form onSubmit={handleSubmit} className="add-civ-form">
            <input
              type="text"
              name="name"
              placeholder="Civilization Name"
              value={newCiv.name}
              onChange={handleInputChange}
              required
            />
            <input
              type="number"
              name="population"
              placeholder="Population"
              value={newCiv.population}
              onChange={handleInputChange}
              required
            />
            <button type="submit">Create</button>
          </form>
        )}
      </div>
    </div>
  );
};

export default CivilizationList;

import React, { useState, useEffect } from "react";
import { getCivilization, evolveCivilization } from "../services/api";

const CivilizationDetails = ({ id, onEvolve }) => {
  const [civilization, setCivilization] = useState(null);
  const [eventsLogs, setEventsLogs] = useState([]);
  const [typingLog, setTypingLog] = useState("");
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchCivilization = async () => {
      try {
        setError(null);
        setEventsLogs([]); // Reset event logs
        const data = await getCivilization(id);
        setCivilization(data);
        const existingEventLogs = data.events;
        setEventsLogs(existingEventLogs.reverse()); // Reverse logs initially
      } catch (err) {
        setError("Failed to load civilization.");
        console.error(err.message);
      }
    };

    fetchCivilization();
  }, [id]);

  const handleEvolve = async (turns) => {
    try {
      await evolveCivilization(id, turns);
      const data = await getCivilization(id);
      setCivilization(data);

      const newLogs = data.events || [];
      const logsToType = newLogs.slice(-turns); // Only type the latest `turns` logs
      startTypingEffect(logsToType); // Begin typing effect

      onEvolve(data); // Notify parent about the updated civilization
    } catch (err) {
      setError("Failed to evolve civilization.");
      console.error(err.message);
    }
  };

  const startTypingEffect = (logsToType) => {
    let logIndex = 0;

    const typeLog = () => {
      if (logIndex >= logsToType.length) return; // Stop typing if all logs are done

      const currentLog = logsToType[logIndex];
      let charIndex = 0;
      let typedLog = ""; // The currently typed log

      const typeCharacter = () => {
        if (charIndex < currentLog.description.length) {
          typedLog += currentLog.description[charIndex]; // Add the next character
          setTypingLog(`Year ${currentLog.year} - ${typedLog}`); // Update the state with the partial log
          charIndex++;
          setTimeout(typeCharacter, 50); // Typing speed
        } else {
          // Typing of this log is complete
          setEventsLogs((prev) => [currentLog, ...prev]); // Add the completed log to the top
          setTypingLog(""); // Clear typing log
          logIndex++;
          setTimeout(typeLog, 200); // Delay before typing the next log
        }
      };

      typeCharacter(); // Start typing the first character of the current log
    };

    typeLog(); // Start typing the first log
  };

  if (error) return <p>{error}</p>;
  if (!civilization) return <p>Loading...</p>;

  const isPopulationZero = civilization.population <= 0;

  return (
    <div className="civilization-details">
      <div className="details-info">
        <h2>{civilization.name}</h2>
        <div>Population: {civilization.population}</div>
        <div>Current Year: {civilization.currentYear || 0}</div>

        {!isPopulationZero && (
          <div>
            <button onClick={() => handleEvolve(1)}>Evolve 1 Year</button>
            <button onClick={() => handleEvolve(5)}>Evolve 5 Years</button>
          </div>
        )}
      </div>

      <div className="console">
        {/* Typing log is displayed at the top */}
        {typingLog && <p className="typing">{typingLog}</p>}
        {/* Render existing logs in descending order */}
        {[...eventsLogs].map((log, index) => (
          <p key={index}>
            Year {log.year} - {log.description}
          </p>
        ))}
      </div>
    </div>
  );
};

export default CivilizationDetails;

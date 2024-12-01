import React, { useState } from "react";
import Header from "./components/Header";
import CivilizationList from "./components/CivilizationList";
import CivilizationDetails from "./components/CivilizationDetails";

const App = () => {
  const [selectedCivilizationId, setSelectedCivilizationId] = useState(null);
  const [updatedCivilization, setUpdatedCivilization] = useState(null);

  return (
    <div className="app">
      <Header />
      <main className="main">
        <CivilizationList
          onSelect={setSelectedCivilizationId}
          updatedCivilization={updatedCivilization}
        />
        {selectedCivilizationId && (
          <CivilizationDetails
            id={selectedCivilizationId}
            onEvolve={(updatedCiv) => setUpdatedCivilization(updatedCiv)}
          />
        )}
      </main>
    </div>
  );
};

export default App;

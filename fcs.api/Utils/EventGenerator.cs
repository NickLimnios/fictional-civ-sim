using fcs.api.Models;

namespace fcs.api.Utils
{
    public static class EventGenerator
    {
        private static readonly Random _random = new Random();

        public static Event GenerateCreationEvent(Civilization civilization)
        {
            var startingEvents = new List<string>
            {
                $"The dawn of a new civilization. The {civilization.Name}.",
                $"{civilization.Name} rose to power.",
                $"The world welcomes the {civilization.Name} civilization.",
                $"{civilization.Name} founded.",
                $"A golden age begins with the birth of {civilization.Name}."
            };
            var selectedStartingEvent = startingEvents[_random.Next(startingEvents.Count)];
            return new Event { Year = 0, Description = selectedStartingEvent };
        }

        public static Event GenerateRandomEvent(Civilization civilization)
        {
            var events = new List<Func<Civilization, Event>>
            {
                ApplyPopulationGrowth,
                ApplyNaturalDisaster,
                ApplyTechnologicalAdvancement,
                ApplyCulturalExpansion,
                ApplyMilitaryConflict
            };

            // Pick a random event and apply it
            var selectedEvent = events[_random.Next(events.Count)];
            return selectedEvent(civilization);
        }

        private static Event ApplyPopulationGrowth(Civilization civilization)
        {
            civilization.CurrentYear++;
            int growth = _random.Next(5, 21); // Random growth between 5 and 20
            var growthDescriptions = new List<string>
            {
                $"Population surged by {growth} due to improved agriculture.",
                $"An era of prosperity increased the population by {growth}.",
                $"Birth rates soared, adding {growth} to the population."
            };
            var selectedDescription = growthDescriptions[_random.Next(growthDescriptions.Count)];
            civilization.Population += growth;
            return new Event
            {
                CivilizationId = civilization.Id,
                Year = civilization.CurrentYear,
                Description = selectedDescription
            };
        }

        private static Event ApplyNaturalDisaster(Civilization civilization)
        {
            civilization.CurrentYear++;
            int loss = _random.Next(10, 31); // Random loss between 10 and 30
            var disasterDescriptions = new List<string>
            {
                $"A devastating flood reduced the population by {loss}.",
                $"A powerful earthquake caused {loss} casualties.",
                $"A severe drought led to a population decrease of {loss}."
            };
            var selectedDescription = disasterDescriptions[_random.Next(disasterDescriptions.Count)];
            civilization.Population = Math.Max(0, civilization.Population - loss);
            return new Event
            {
                CivilizationId = civilization.Id,
                Year = civilization.CurrentYear,
                Description = $"{selectedDescription}"
            };
        }

        private static Event ApplyTechnologicalAdvancement(Civilization civilization)
        {
            civilization.CurrentYear++;
            var advancements = new List<string>
            {
                "Iron tools",
                "Writing system",
                "Advanced agriculture",
                "Early mathematics",
                "Irrigation systems",
                "Bronze weapons"
            };
            string advancement = advancements[_random.Next(advancements.Count)];
            civilization.Technology = advancement;
            return new Event
            {
                CivilizationId = civilization.Id,
                Year = civilization.CurrentYear,
                Description = $"The civilization achieved a technological breakthrough: {advancement}."
            };
        }

        private static Event ApplyCulturalExpansion(Civilization civilization)
        {
            civilization.CurrentYear++;
            var culturalAchievements = new List<string>
            {
                "A renowned poet composed epic tales.",
                "New art styles flourished, inspiring generations.",
                "Cultural exchanges brought new traditions and festivals."
            };
            var selectedAchievement = culturalAchievements[_random.Next(culturalAchievements.Count)];
            return new Event
            {
                CivilizationId = civilization.Id,
                Year = civilization.CurrentYear,
                Description = $"{selectedAchievement}"
            };
        }

        private static Event ApplyMilitaryConflict(Civilization civilization)
        {
            civilization.CurrentYear++;
            int populationLoss = _random.Next(10, 51); // Random loss between 10 and 50
            var conflictDescriptions = new List<string>
            {
                $"A fierce battle led to the loss of {populationLoss} lives.",
                $"Neighboring tribes raided, reducing the population by {populationLoss}.",
                $"A war effort took {populationLoss} lives but secured new territory."
            };
            var selectedDescription = conflictDescriptions[_random.Next(conflictDescriptions.Count)];
            civilization.Population = Math.Max(0, civilization.Population - populationLoss);
            return new Event
            {
                CivilizationId = civilization.Id,
                Year = civilization.CurrentYear,
                Description = selectedDescription
            };
        }
    }
}

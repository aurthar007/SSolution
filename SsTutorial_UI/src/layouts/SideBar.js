// src/components/SideBar.jsx
import { Link } from "react-router-dom";
import useAuthStore from "../store/useAuthStore";
import useSelectionStore from "../store/useSelectionStore";
import {
  FaUserShield,
  FaTasks,
  FaGlobe,
  FaMapMarkedAlt,
  FaMap,
  FaUserTag
} from 'react-icons/fa';
import '../App.css';

// Sample topics mapped by standard and subject
const topicData = {
  "1": {
    Math: ["Numbers", "Addition", "Shapes", "Subtraction", "Multiplication", "Patterns", "Measurement"],
    Science: ["Plants", "Animals", "Living and Non-living", "Seasons", "Weather", "Soil", "Human Body"],
    English: ["Alphabets", "Phonics", "Nouns", "Verbs", "Adjectives", "Sentences", "Punctuation"],
    History: ["Early Humans", "Stone Age", "Bronze Age", "Farming", "Inventions", "Early Civilizations", "Social Structures"]
  },
  "2": {
    Math: ["Multiplication", "Division", "Addition", "Subtraction", "Shapes", "Patterns", "Time"],
    Science: ["Water", "Earth", "Animals", "Reptiles", "Plants", "Habitats", "Day and Night"],
    English: ["Grammar", "Comprehension", "Tenses", "Sentences", "Verbs", "Nouns", "Adjectives"],
    History: ["Kings and Kingdoms", "Ancient Civilizations", "Famous Kings", "Medieval Period", "The First Empires", "Feudal Systems", "Trade Routes"]
  },
  "3": {
    Math: ["Fractions", "Decimals", "Addition", "Subtraction", "Multiplication", "Division", "Data Handling"],
    Science: ["Matter", "Force", "Simple Machines", "Magnetism", "Electricity", "Earth and Moon", "Water Cycle"],
    English: ["Tenses", "Vocabulary", "Punctuation", "Prepositions", "Conjunctions", "Writing Skills", "Creative Writing"],
    History: ["Independence Movement", "Colonial India", "World Wars", "Freedom Fighters", "Modern History", "National Heroes", "Revolutionaries"]
  },
  "4": {
    Math: ["Algebra", "Geometry", "Number Theory", "Fractions", "Decimals", "Data and Graphs", "Patterns"],
    Science: ["Energy", "Environment", "Human Body", "Photosynthesis", "Weather Patterns", "Forces and Motion", "Sound"],
    English: ["Essay Writing", "Speech", "Grammar", "Tenses", "Paragraph Writing", "Report Writing", "Punctuation"],
    History: ["World Wars", "Ancient Civilizations", "Industrial Revolution", "Modern World", "Famous Leaders", "Scientific Revolution", "Global Trade"]
  },
  "5": {
    Math: ["Calculus", "Trigonometry", "Statistics", "Algebra", "Geometry", "Probability", "Linear Equations"],
    Science: ["Astronomy", "Chemistry", "Ecology", "Electricity and Magnetism", "Earthquakes", "Atoms and Molecules", "The Solar System"],
    English: ["Literature", "Writing Skills", "Poetry", "Drama", "Essays", "Fiction Writing", "Comprehension"],
    History: ["Modern History", "Ancient Empires", "Revolutionary Movements", "Famous Historical Figures", "Global Conflicts", "Colonization", "Independence Movements"]
  }
};


const SideBar = () => {
  const role = useAuthStore((state) => state.role);
  const { standard, subject } = useSelectionStore();

  const topics = topicData[standard]?.[subject] || [];

  return (
    <aside className="sidebar">
      <ul>

        {/* Admin Menu */}
        {role === "Admin" && (
          <li className="sidebar-item">
            <Link to="/assignrole" className="sidebar-link"><FaUserTag /> Assign Role</Link><br /><br />
            <Link to="/role" className="sidebar-link"><FaUserShield /> Role</Link><br /><br />
            <Link to="/taskmanager" className="sidebar-link"><FaTasks /> Task Manager</Link><br /><br />
            <Link to="/country" className="sidebar-link"><FaGlobe /> Country</Link><br /><br />
            <Link to="/state" className="sidebar-link"><FaMapMarkedAlt /> State</Link><br /><br />
            <Link to="/district" className="sidebar-link"><FaMap /> District</Link>
          </li>
        )}

        {/* Student Topics */}
        {standard && subject && topics.length > 0 && (
          <li className="sidebar-item">
            <strong>Topics for Std. {standard} - {subject.charAt(0).toUpperCase() + subject.slice(1)}:</strong>
            <ul className="sidebar-subtopics">
              {topics.map((topic, idx) => (
                <li key={idx}>
                  <Link
                    to={`/topics/${standard}/${subject}/${topic.toLowerCase().replace(/\s+/g, '-')}`}
                    className="sidebar-link"
                  >
                    • {topic}
                  </Link>
                </li>
              ))}
            </ul>
          </li>
        )}

      </ul>
    </aside>
  );
};

export default SideBar;

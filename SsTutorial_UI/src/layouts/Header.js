import { FaSignOutAlt } from "react-icons/fa";
import { useNavigate } from "react-router-dom";
import useAuthStore from "../store/useAuthStore";
import useSelectionStore from "../store/useSelectionStore";

const Header = ({ showStudentDropdowns }) => {
  const logout = useAuthStore((state) => state.logout);
  const user = useAuthStore((state) => state.user);
  const role = useAuthStore((state) => state.role);
  const navigate = useNavigate();

  const { setStandard, setSubject, standard, subject } = useSelectionStore();

  const handleLogout = () => {
    logout();
    navigate('/');
  };

  const handleStandardChange = (e) => {
    setStandard(e.target.value);
  };

  const handleSubjectChange = (e) => {
    setSubject(e.target.value);
  };

  return (
    <header className="dashboard-header">
      <div className="logo">Shiwansh Tutorial</div>

      {showStudentDropdowns && (
        <div className="student-dropdowns">
          <select name="standard" className="dropdown" value={standard} onChange={handleStandardChange}>
            <option value="">Select Standard</option>
            <option value="1">1st</option>
            <option value="2">2nd</option>
            <option value="3">3rd</option>
            <option value="4">4th</option>
            <option value="5">5th</option>
          </select>

          <select name="subject" className="dropdown" value={subject} onChange={handleSubjectChange}>
            <option value="">Select Subject</option>
            <option value="Math">Math</option>
            <option value="Science">Science</option>
            <option value="English">English</option>
            <option value="History">History</option>
          </select>
        </div>
      )}

      <div className="header-right">
        {user && (
          <>
            <img
              src={`/${user.firstname}.jpg`}
              alt="User Icon"
              className="user-icon"
              style={{ width: '30px', height: '30px', cursor: 'pointer' }}
            />
            <span className="username">
              {user.firstname} {user.lastname} ({role})
            </span>
          </>
        )}

        <FaSignOutAlt
          className="icon"
          onClick={handleLogout}
          title="Logout"
          style={{ cursor: 'pointer' }}
        />
      </div>
    </header>
  );
};

export default Header;

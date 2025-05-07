import React from 'react';
import '../../App.css';
import { Outlet } from 'react-router-dom';
import Header from '../Header';
import Footer from '../Footer';
import SideBar from '../SideBar';

const StudentLayout = () => {
  return (
    <div className="dashboard-container">
      <Header showStudentDropdowns={true} />
      <div className="dashboard-body">
        <SideBar />
        <main className="main-content">
          <Outlet />
        </main>
      </div>
      <Footer />
    </div>
  );
};

export default StudentLayout;

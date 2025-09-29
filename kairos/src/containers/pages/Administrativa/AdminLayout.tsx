import { Outlet } from 'react-router-dom';
import './AdminLayout.css';
import Sidebar from '../../../components/shared/Sidebar/SideBar';

export default function AdminLayout() {
  return (
    <div className='layoutContainer'>
        <div className="admin-layout">
          <Sidebar />
          <main className="admin-content">
            <Outlet />
          </main>
        </div>
    </div>
    
  );
}

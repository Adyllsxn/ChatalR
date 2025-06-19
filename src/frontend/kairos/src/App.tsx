import { Routes, Route } from 'react-router-dom';

import Home   from './containers/pages/Home';
import Header from './components/layouts/Header/Header';
import Footer from './components/layouts/Footer/Footer';

import './core/style/App.css';

function App() {

  return (
    <>
      <Header/>
        <Routes>
          <Route path="/" element={<Home />} />
        </Routes>
      <Footer />
    </>
  )
}

export default App

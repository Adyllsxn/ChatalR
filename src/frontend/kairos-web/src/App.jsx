import Header from './components/Header'
import Footer from './components/Footer'
import Home from './pages/Home/Home'
import { Routes, Route } from 'react-router-dom'
import './styles/App.css'

function App() {
  return (
    <>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
      </Routes>
      <Footer />
    </>
  )
}

export default App

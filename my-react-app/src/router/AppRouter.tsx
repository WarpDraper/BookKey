import { Routes, Route } from 'react-router-dom'
import { Layout } from '../components/layout/Layout'
// import Catalog from '../pages/Catalog'
import BookDetails from '../pages/BookDetails'
import Home from '../pages/Home'
import Login from '../pages/Login'
import Register from '../pages/Register'
import Profile from '../pages/Profile'
import NotFound from '../pages/404'

export default function AppRouter() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route path="/" element={<Home />} />
        {/* <Route path="/catalog" element={<Catalog />} /> */}
        <Route path="/catalog/:id" element={<BookDetails />} />
        <Route path='/login' element={<Login/>} />
        <Route path='/register' element={<Register/>} />
        <Route path='/profile' element={<Profile/>} />
        <Route path="*" element={<NotFound/>} />

      </Route>
    </Routes>
  )
}

import React from 'react'
import ReactDOM from 'react-dom/client'
import Layout from './layout/Layout.tsx'
import '../assets/styles/index.css'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Layout />
  </React.StrictMode>,
)

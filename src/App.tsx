import './App.css'
import { Button } from "@/components/ui/button"


function App() {
  return (
    <div className="p-8 flex flex-col items-start gap-4">
      <h1 className="text-4xl font-bold text-blue-600">
        Tailwind Vite plugin funcionando 🔥
      </h1>

      <Button>Click Me</Button>
      <Button variant="destructive">Delete</Button>
      <Button variant="outline">Outline</Button>
      <Button variant="secondary">Secondary</Button>
      <Button variant="ghost">Ghost</Button>
      <Button variant="link">Link</Button>
    </div>
  )
}

export default App


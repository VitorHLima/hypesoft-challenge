"use client"

import { Search as SearchIcon } from "lucide-react"
import { Input } from "@/components/ui/input"

export default function Search() {
  return (
    <div className="relative w-full max-w-md">
      <SearchIcon className="absolute left-3 top-1/2 h-4 w-4 -translate-y-1/2 text-muted-foreground" />
      <Input
        type="search"
        placeholder="Search"
        className="pl-10 h-9"
      />
    </div>
  )
}

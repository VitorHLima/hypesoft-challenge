"use client"

import { Bell, Moon, MoreVertical, ChevronDown } from "lucide-react"
import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"

export default function HeaderActions() {
  return (
    <div className="flex items-center gap-2">
      {/* Theme Toggle */}
      <Button variant="ghost" size="icon" className="h-9 w-9">
        <Moon className="h-4 w-4" />
      </Button>

      {/* Notifications */}
      <Button variant="ghost" size="icon" className="h-9 w-9 relative">
        <Bell className="h-4 w-4" />
        <span className="absolute right-1.5 top-1.5 h-2 w-2 rounded-full bg-red-600" />
      </Button>

      {/* User Menu */}
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button variant="ghost" className="flex items-center gap-2 h-9">
            <Avatar className="h-8 w-8">
              <AvatarImage src="/avatar.png" alt="User" />
              <AvatarFallback>VH</AvatarFallback>
            </Avatar>
            <div className="flex flex-col items-start text-xs">
              <span className="font-medium">Vitor Hugo</span>
              <span className="text-muted-foreground">Shop Admin</span>
            </div>
            <ChevronDown className="h-3 w-3 text-muted-foreground" />
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align="end" className="w-48">
          <DropdownMenuLabel>Minha Conta</DropdownMenuLabel>
          <DropdownMenuSeparator />
          <DropdownMenuItem>Perfil</DropdownMenuItem>
          {/* <DropdownMenuItem>Configurações</DropdownMenuItem> */}
          <DropdownMenuSeparator />
          <DropdownMenuItem>Sair</DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>

      {/* More Options */}
      <Button variant="ghost" size="icon" className="h-9 w-9">
        <MoreVertical className="h-4 w-4" />
      </Button>
    </div>
  )
}

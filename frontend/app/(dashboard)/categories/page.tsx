"use client"

import { CategoryModal } from "@/components/forms/category-modal"
import { useCategories, useDeleteCategory } from "@/hooks/useCategories"
import { Button } from "@/components/ui/button"
import { Trash2 } from "lucide-react"

export default function CategoriesPage() {
  const { data: categories = [], isLoading } = useCategories()
  const { mutate: deleteCategory } = useDeleteCategory()

  const handleDelete = (id: string) => {
    if (confirm("Tem certeza que deseja excluir esta categoria?")) {
      deleteCategory(id)
    }
  }

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold tracking-tight">Categorias</h1>
          <p className="text-muted-foreground">
            Gerencie as categorias dos produtos
          </p>
        </div>
        <CategoryModal />
      </div>

      <div className="rounded-lg border bg-card">
        {isLoading ? (
          <div className="p-6">
            <p className="text-sm text-muted-foreground">Carregando...</p>
          </div>
        ) : categories.length === 0 ? (
          <div className="p-6">
            <p className="text-sm text-muted-foreground">
              Nenhuma categoria cadastrada ainda.
            </p>
          </div>
        ) : (
          <div className="divide-y">
            {categories.map((category) => (
              <div
                key={category.id}
                className="flex items-center justify-between p-4 hover:bg-muted/50 transition-colors"
              >
                <div>
                  <h3 className="font-medium">{category.name}</h3>
                  <p className="text-sm text-muted-foreground">
                    ID: {category.id}
                  </p>
                </div>
                <Button
                  variant="ghost"
                  size="icon"
                  onClick={() => handleDelete(category.id)}
                >
                  <Trash2 className="h-4 w-4 text-red-500" />
                </Button>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  )
}

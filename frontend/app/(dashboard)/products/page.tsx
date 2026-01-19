"use client"

import { ProductModal } from "@/components/forms/product-modal"
import { useProducts, useDeleteProduct } from "@/hooks/useProducts"
import { Button } from "@/components/ui/button"
import { Trash2 } from "lucide-react"

export default function ProductsPage() {
  const { data: productsData, isLoading } = useProducts()
  const { mutate: deleteProduct } = useDeleteProduct()

  const handleDelete = (id: string) => {
    if (confirm("Tem certeza que deseja excluir este produto?")) {
      deleteProduct(id)
    }
  }

  const formatCurrency = (value: number) => {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL',
    }).format(value)
  }

  const products = productsData?.data || []

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold tracking-tight">Produtos</h1>
          <p className="text-muted-foreground">
            Gerencie todos os seus produtos
          </p>
        </div>
        <ProductModal />
      </div>

      <div className="rounded-lg border bg-card">
        {isLoading ? (
          <div className="p-6">
            <p className="text-sm text-muted-foreground">Carregando...</p>
          </div>
        ) : products.length === 0 ? (
          <div className="p-6">
            <p className="text-sm text-muted-foreground">
              Nenhum produto cadastrado ainda.
            </p>
          </div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full">
              <thead>
                <tr className="border-b bg-muted/50">
                  <th className="p-4 text-left font-medium">Nome</th>
                  <th className="p-4 text-left font-medium">Descrição</th>
                  <th className="p-4 text-left font-medium">Preço</th>
                  <th className="p-4 text-left font-medium">Estoque</th>
                  <th className="p-4 text-left font-medium">Categoria</th>
                  <th className="p-4 text-right font-medium">Ações</th>
                </tr>
              </thead>
              <tbody>
                {products.map((product: any) => (
                  <tr key={product.id} className="border-b hover:bg-muted/50 transition-colors">
                    <td className="p-4 font-medium">{product.name}</td>
                    <td className="p-4 text-sm text-muted-foreground">{product.description}</td>
                    <td className="p-4">{formatCurrency(product.price)}</td>
                    <td className="p-4">
                      <span className={product.stock < 10 ? "text-red-500 font-medium" : ""}>
                        {product.stock}
                      </span>
                    </td>
                    <td className="p-4 text-sm">{product.category?.name || '-'}</td>
                    <td className="p-4 text-right">
                      <Button
                        variant="ghost"
                        size="icon"
                        onClick={() => handleDelete(product.id)}
                      >
                        <Trash2 className="h-4 w-4 text-red-500" />
                      </Button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
    </div>
  )
}

"use client"

import ChartAreaLinear from '../../../components/charts/area-chart'
import ChartBarLinear from '../../../components/charts/bar-chart'
import { useDashboardStats, useDashboardSales } from '@/hooks/useDashboard'

export default function DashboardPage() {
  const { data: stats, isLoading } = useDashboardStats()
  const { data: salesData } = useDashboardSales()

  const formatCurrency = (value: number) => {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL',
    }).format(value)
  }

  return (
    <div className="space-y-6">
      <div>
        <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
        <p className="text-muted-foreground">
          Visão geral do sistema de gestão de produtos
        </p>
      </div>

      {/* Cards de Estatísticas */}
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
        <div className="rounded-lg border bg-card p-6 text-card-foreground shadow-sm">
          <div className="flex flex-row items-center justify-between space-y-0 pb-2">
            <h3 className="text-sm font-medium">Total de Produtos</h3>
          </div>
          <div className="text-2xl font-bold">
            {isLoading ? '...' : stats?.totalProducts || 0}
          </div>
        </div>
        
        <div className="rounded-lg border bg-card p-6 text-card-foreground shadow-sm">
          <div className="flex flex-row items-center justify-between space-y-0 pb-2">
            <h3 className="text-sm font-medium">Valor Total do Estoque</h3>
          </div>
          <div className="text-2xl font-bold">
            {isLoading ? '...' : formatCurrency(stats?.totalValue || 0)}
          </div>
        </div>

        <div className="rounded-lg border bg-card p-6 text-card-foreground shadow-sm">
          <div className="flex flex-row items-center justify-between space-y-0 pb-2">
            <h3 className="text-sm font-medium">Estoque Baixo</h3>
          </div>
          <div className="text-2xl font-bold">
            {isLoading ? '...' : stats?.lowStockCount || 0}
          </div>
        </div>

        <div className="rounded-lg border bg-card p-6 text-card-foreground shadow-sm">
          <div className="flex flex-row items-center justify-between space-y-0 pb-2">
            <h3 className="text-sm font-medium">Categorias</h3>
          </div>
          <div className="text-2xl font-bold">
            {isLoading ? '...' : stats?.totalCategories || 0}
          </div>
        </div>
      </div>

      {/* Gráficos */}
      <div className="grid gap-4 md:grid-cols-2">
        <ChartAreaLinear className="w-full" data={salesData} />
        <ChartBarLinear className="w-full" data={salesData} />
      </div>
    </div>
  )
}

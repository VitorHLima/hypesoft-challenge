export interface DashboardStats {
  totalProducts: number;
  totalStockValue: number;
  lowStockProducts: number;
  productsByCategory: CategoryStats[];
}

export interface CategoryStats {
  category: string;
  count: number;
}

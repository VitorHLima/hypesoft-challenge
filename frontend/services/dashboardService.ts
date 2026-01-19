import apiClient from '@/lib/axios';

export interface DashboardStats {
  totalProducts: number;
  totalCategories: number;
  lowStockCount: number;
  totalValue: number;
}

export interface SalesData {
  month: string;
  sales: number;
}

export const dashboardService = {
  getStats: async () => {
    const response = await apiClient.get<DashboardStats>('/dashboard/stats');
    return response.data;
  },
  
  getSales: async () => {
    const response = await apiClient.get<SalesData[]>('/dashboard/sales');
    return response.data;
  },
};

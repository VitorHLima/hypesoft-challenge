import { useQuery } from '@tanstack/react-query';
import { dashboardService } from '@/services/dashboardService';

export const useDashboardStats = () => {
  return useQuery({
    queryKey: ['dashboard', 'stats'],
    queryFn: () => dashboardService.getStats(),
  });
};

export const useDashboardSales = () => {
  return useQuery({
    queryKey: ['dashboard', 'sales'],
    queryFn: () => dashboardService.getSales(),
  });
};

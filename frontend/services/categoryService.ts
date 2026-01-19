import apiClient from '@/lib/axios';
import { Category } from '@/types/product';

export const categoryService = {
  getAll: async () => {
    const response = await apiClient.get<Category[]>('/categories');
    return response.data;
  },

  create: async (name: string) => {
    const response = await apiClient.post<Category>('/categories', { name });
    return response.data;
  },

  delete: async (id: string) => {
    await apiClient.delete(`/categories/${id}`);
  },
};

import apiClient from '@/lib/axios';
import { Product, ProductFormData } from '@/types/product';

export const productService = {
  getAll: async (page = 1, limit = 10, search?: string, category?: string) => {
    const params = new URLSearchParams({
      page: page.toString(),
      limit: limit.toString(),
      ...(search && { search }),
      ...(category && { category }),
    });
    const response = await apiClient.get<{ data: Product[]; total: number }>(`/products?${params}`);
    return response.data;
  },

  getById: async (id: string) => {
    const response = await apiClient.get<Product>(`/products/${id}`);
    return response.data;
  },

  create: async (data: ProductFormData) => {
    const response = await apiClient.post<Product>('/products', data);
    return response.data;
  },

  update: async (id: string, data: Partial<ProductFormData>) => {
    const response = await apiClient.put<Product>(`/products/${id}`, data);
    return response.data;
  },

  delete: async (id: string) => {
    await apiClient.delete(`/products/${id}`);
  },

  getLowStock: async () => {
    const response = await apiClient.get<Product[]>('/products/low-stock');
    return response.data;
  },
  getAllProducts: async () => {
    const response = await apiClient.get<Product[]>('/products/all');
    return response.data;
  }
};

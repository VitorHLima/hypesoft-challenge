# Sistema de Gestão de Produtos

Sistema completo de gerenciamento de produtos com frontend moderno e backend em Clean Architecture.

## Stack Tecnológica

**Frontend**
- Next.js 14 com TypeScript
- TailwindCSS v4
- Shadcn/ui
- React Query
- React Hook Form + Zod
- Recharts

**Backend**
- .NET 9 com C#
- Clean Architecture + DDD + CQRS
- MediatR
- MongoDB
- Swagger

**Infraestrutura**
- Docker + Docker Compose
- Nginx (load balancer)
- MongoDB Express

## Funcionalidades

- CRUD completo de produtos
- CRUD completo de categorias
- Dashboard com estatísticas e gráficos
- Validação de dados no frontend e backend
- Atualização automática da interface
- Testes unitários (8 testes passando)

## Como Rodar

```bash
docker-compose up -d --build
```

**Acessar:**
- Frontend: http://localhost:3000
- API: http://localhost:5000
- Swagger: http://localhost:5000/swagger
- MongoDB Express: http://localhost:8081

## Arquitetura

Backend estruturado em 4 camadas:
- **Domain**: Entidades e interfaces
- **Application**: Lógica de negócio (CQRS handlers)
- **Infrastructure**: Repositórios MongoDB
- **API**: Controllers REST

Frontend com padrão modular:
- Componentes reutilizáveis
- Hooks customizados com React Query
- Serviços para comunicação com API
- Validação com Zod schemas

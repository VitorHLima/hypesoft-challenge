import Link from "next/link";
import { Package } from "lucide-react";

export default function Home() {
  return (
    <div className="flex min-h-screen flex-col items-center justify-center bg-gradient-to-b from-background to-muted px-4">
      <div className="flex flex-col items-center text-center">
        <div className="mb-6 flex h-16 w-16 items-center justify-center rounded-2xl bg-primary text-primary-foreground">
          <Package className="h-8 w-8" />
        </div>
        
        <h1 className="mb-4 text-5xl font-bold tracking-tight">
          Bem-vindo ao Hypesoft!
        </h1>
        
        <p className="mb-8 max-w-md text-lg text-muted-foreground">
          Seu sistema completo de gestão de produtos, estoque e categorias.
        </p>
        
        <Link
          href="/dashboard"
          className="inline-flex items-center justify-center rounded-md bg-primary px-8 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90"
        >
          Acessar Dashboard
        </Link>
      </div>
    </div>
  );
}

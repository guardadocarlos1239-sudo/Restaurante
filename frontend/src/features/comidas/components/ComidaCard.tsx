
 // --- ZONA 1: EL CONTRATO (INTERFAZ EXPORTADA) ---
// Espejo de nuestra entidad Comida en PostgreSQL y DTO en C#.
export interface ComidaProps {
    id: number;
    nombre: string;
    precio: number;
}

// --- ZONA 2: LA FIRMA ---
export function ComidaCard({ id, nombre, precio }: ComidaProps) {

    // --- ZONA 3: EL CEREBRO (LÓGICA) ---
    // Componente presentacional puro.

    // --- ZONA 4: EL RENDERIZADO (APLICANDO DESIGN TOKENS) ---
    return (
        <article className="bg-slate-800 border border-slate-700 rounded-xl p-5 flex flex-col justify-between hover:border-indigo-500 transition-colors shadow-sm">

            <div>
                <div className="flex items-center justify-between mb-3">
                    <span className="bg-indigo-500/10 text-indigo-400 text-xs font-semibold px-2.5 py-1 rounded-md border border-indigo-500/20">
                        ID Comida #{id}
                    </span>

                    <span className="text-xs text-slate-400 font-medium">
                        Catálogo Restaurante
                    </span>
                </div>

                <h3 className="text-lg font-bold text-white mb-3">
                    {nombre}
                </h3>

                <p className="text-xl font-bold text-emerald-400 mb-5">
                    L. {precio.toFixed(2)}
                </p>
            </div>

            <button
                disabled
                className="w-full bg-slate-900/80 text-slate-400 text-sm font-medium py-2.5 px-4 rounded-lg cursor-not-allowed border border-slate-700"
            >
                🔒 Agregar al pedido (Requiere Sesión)
            </button>
        </article>
    );
}


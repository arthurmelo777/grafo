namespace Grafo {
    public class Vertice  {
        private object id;
        private object? valor;
        private Aresta[]? arestas;

        public object Id {
            get { return id; }
            set { id = value; }
        }

        public object Valor {
            get { return valor; }
            set { valor = value; }
        }

        public Aresta[] GetArestas () {
            return arestas;
        }

        public void AdicionarAresta (Aresta a) {
            arestas.Append(a);
        }

        public Vertice (object id, object? v) {
            this.id = id;
            valor = v;
        }
    }

    public class Aresta {
        private object? valor;
        private Vertice vEsq, vDir;

        public object Valor {
            get { return valor; }
            set { valor = value; }
        }

        public Vertice VEsq {
            get { return vEsq; }
            set { vEsq = value; }
        }

        public Vertice VDir {
            get { return vDir; }
            set { vDir = value; }
        }

        public Aresta (object? v, Vertice ve, Vertice vd) {
            valor = v;
            vEsq = ve;
            vDir = vd;
        }
    }

    public class Grafo {
        private Vertice[] vertices;
        private Aresta[] arestas;
        
        public Vertice[] GetVertices () {
            return vertices;
        }

        public Aresta[] GetArestas () {
            return arestas;
        }

        public int GetOrdem () {
            return vertices.Length;
        }

        public int GetTamanho () {
            return vertices.Length + arestas.Length;
        }

        public Vertice[] GetVizinhancaAberta (Vertice v) {
            Vertice[] vizinhanca = [];

            foreach (Aresta a in arestas) {
                if (a.VDir == v) { vizinhanca.Append(a.VEsq); }
                else if (a.VEsq == v) { vizinhanca.Append(a.VDir); }
            }

            return vizinhanca;
        }

        public Vertice[] GetVizinhancaFechada (Vertice v) {
            Vertice[] vizinhanca = [v];

            foreach (Aresta a in arestas) {
                if (a.VDir == v) { vizinhanca.Append(a.VEsq); }
                else if (a.VEsq == v) { vizinhanca.Append(a.VDir); }
            }

            return vizinhanca;
        }

        public int GetGrau (Vertice v) {
            int grau = 0;

            foreach (Aresta a in arestas) {
                if (a.VDir == v || a.VEsq == v) { grau++; }
            }

            return grau;
        }

        // Verificações
        public bool EhTrivial () { // Grafo possui um único vértice
            return vertices.Length == 1;
        }

        public bool EhNulo () { // Grafo não possui nenhum vértice
            return vertices.Length == 0;
        }

        public bool EhRegular () { // Grafo possui todos os vértices com mesmo grau
            int grau = GetGrau(vertices[0]);

            for (int i = 1; i < vertices.Length; i++) {
                if (grau != GetGrau(vertices[i])) return false;
            }

            return true;
        }

        public bool EhKRegular (int k) {
            foreach (Vertice v in vertices) {
                if (k != GetGrau(v)) return false;
            }

            return true;
        }

        public int GetGrauMaximo () {
            int[] graus = [];
            
            foreach (Vertice v in vertices) {
                graus.Append(GetGrau(v));
            }

            return graus.Max();
        }

        public int GetGrauMinimo () {
            int [] graus = [];

            foreach (Vertice v in vertices) {
                graus.Append(GetGrau(v));
            }

            return graus.Min();
        }

        public Grafo (Vertice v) {
            vertices = [v];
        }
    }

    public class Teste {

    }
}
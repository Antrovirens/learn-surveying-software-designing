"""defgraph.py"""

'''
class Vertex(object):
    def __init__(self,name):
        self.name = name
        self.adjs = []
        self.adjsname = []
        self.isdestn = 0
    
    def look_adjs(self):
        L = []
        for v in self.adjs:
            L.append(v.name)
        print(L)

class Edge(object):
    def __init__(self,v,u):
        self.relevances = {v.name:v.adjs, u.name:u.adjs}

    def look_relevances(self):
        L = []
        for vname in self.relevances.keys():
            L.append(vname)
        print(L)

'''
class Graph(object):
    '''undirected unweighted graph'''

    def __init__(self):
        self.VertexNumber = int(0) #点
        self.EdgeNumber = int(0) #边
        self.VertexSet = {}
        self.EdgeSet = []
        self.origin = None
        self.destn = None
        self.O2DPathNum = int(0) #路径数目
    
    def insert_vertex(self,vertex):
        self.VertexSet.setdefault(vertex,[])

    def insert_edge(self,v,u):
        edge = set([v, u])
        if not (edge in self.EdgeSet):
            self.EdgeSet.append(edge)

        '''establish adjacency relationship'''
        if not (u in self.VertexSet[v]):
            self.VertexSet[v].append(u)
        if not (v in self.VertexSet[u]):
            self.VertexSet[u].append(v)

    def get_adjs(self,vertex):
        if vertex in self.VertexSet.keys():
            return self.VertexSet[vertex]
        else:
            print('{} is not in VertexSet'.format(vertex))  

    def look_VertexSet(self):
        L = []
        for v in self.VertexSet.keys():
            L.append(v)    
        print(L)
    
    def look_EdgeSet(self):
        print(self.EdgeSet)

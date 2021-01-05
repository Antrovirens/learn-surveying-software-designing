'''All paths of two vertexs.py'''

import string
from defgraph import *

def initialize_graph(G):
    with open('test2.txt','r') as f:
        G.EdgeNumber = int(f.readline().strip())
        G.VertexNumber = int(f.readline().strip())
        
        '''
        create the EdgeSet and the VertexSet
        notes:enumerate can get the loop count'
        '''
        for i,line in enumerate(f.readlines()):
            if  i == G.EdgeNumber:
                G.origin = line.strip()
            elif i == G.EdgeNumber + 1:
                G.destn = line.strip()
            else:
                u,v = line.strip().split()
            
                G.insert_vertex(v)
                G.insert_vertex(u)

                G.insert_edge(v,u)


def search_path():
    global path
    path = []
    path.append(G.origin)
    visit(G.origin)
    print("Path Number:{}".format(G.O2DPathNum))

def visit(vertex):
    v_adjs = G.get_adjs(vertex) 

    '''whether vertex has adjacences'''
    if v_adjs:
        for u in v_adjs:
            if u == G.destn:
                print(''.join([v for v in path]) + u) 
                G.O2DPathNum += 1
            elif not (u in path):
                path.append(u)
                visit(u)
        '''loop end means that node 'u' has been explored'''
        path.pop()


def main():
    global G
    G = Graph()
    initialize_graph(G)
    '''
    G.look_VertexSet()
    G.look_EdgeSet()
    print(G.get_adjs('A')) 
    '''
    search_path()
    

if __name__ == "__main__":
    main()

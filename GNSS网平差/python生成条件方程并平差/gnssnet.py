#控制点
class ControlPoint(object):
    '''undirected unweighted graph'''

    def __init__(self):
        self.num = int(0) 
        self.name = ""
        self.X = 0.0  #WGS84
        self.Y = 0.0
        self.Z = 0.0
        self.N = 0.0
        self.E = 0.0
        self.H = 0.0

    def init_controlpoint(self,line):
        line = line.rstrip('\n')
        line = line.split(',')
        #文件格式略
        self.num = int(line[0])
        self.name = line[1]
        self.X = float(line[2])
        self.Y = float(line[3])
        self.Z = float(line[4])
        self.N = float(line[5])
        self.E = float(line[6])
        self.H = float(line[7])

    def controlpoint_inf(self):
        return [ self.num ,self.name, self.X, self.Y , self.Z]

    def controlpoint_match(self, point_name):
        if self.name == point_name:
            return True
        else :
            return False


#基线
class Baseline(object):
    '''undirected unweighted graph'''

    def __init__(self):
        self.num = int(0)
        self.origin = "" #起点
        self.target = "" #终点
        self.name = ""
        self.DX = 0.0
        self.DY = 0.0
        self.DZ = 0.0
        self.sigema_DX = 0.0 #中误差
        self.sigema_DY = 0.0
        self.sigema_DZ = 0.0

    def init_baseline(self,line):
        self.num = int(line[0])
        self.origin = line[1]
        self.target = line[2]
        self.name = line[3]
        self.DX = float(line[4])
        self.DY = float(line[5])
        self.DZ = float(line[6])
        self.sigema_DX = float(line[7])
        self.sigema_DY = float(line[8])
        self.sigema_DZ = float(line[9])

    def baseline_inf(self):
        return [self.num,self.origin,self.target,self.name ,self.DX,self.DY,self.DZ,self.sigema_DX,self.sigema_DY,self.sigema_DZ,]
    
    #判断是否为一根基线，方向是否相同，返回基线的编号
    def baseline_match(self,baseline):
        if baseline[0] == self.origin and baseline[1] == self.target:
            return True,1,self.num
        elif baseline[0] == self.target and baseline[1] == self.origin:
            return True,-1,self.num
        else:
            return False,0,-1

#GNSS网
class GNSSNet(object):
    '''undirected unweighted graph'''

    def __init__(self):
        self.BaselineSet = [] #基线集合
        self.ControlPointSet = [] #控制点集合

    def insert_Baseline(self,baseline):
        self.BaselineSet.append(baseline)

    def insert_ControlPoint(self, controlpoint):
        self.ControlPointSet.append(controlpoint)


    def Net_baseline_match(self,baseline):
        for Baseline in self.BaselineSet:
            a,b,c = Baseline.baseline_match(baseline)
            if a:
                return b,self.BaselineSet[c-1].baseline_inf()

    def controlpoint_match(self,point_name):
        for controlpoint in self.ControlPointSet:
            if controlpoint.controlpoint_match(point_name):
                return True,controlpoint.controlpoint_inf()
        return False,None

    #定权  由于基线是用软件算的，没有dxdydz默认互相独立
    def init_P(self,P):
        for Baseline in self.BaselineSet:
            P[Baseline.num*3-3][Baseline.num*3-3] = 1.0 / (Baseline.sigema_DX * Baseline.sigema_DX)
            P[Baseline.num*3-2][Baseline.num*3-2] = 1.0 / (Baseline.sigema_DY * Baseline.sigema_DY)
            P[Baseline.num*3-1][Baseline.num*3-1] = 1.0 / (Baseline.sigema_DZ * Baseline.sigema_DZ)
        return P

    #观测值矩阵
    def init_L(self,L):
        for Baseline in self.BaselineSet:
            L[Baseline.num*3-3][0] = Baseline.DX 
            L[Baseline.num*3-2][0] = Baseline.DY
            L[Baseline.num*3-1][0] = Baseline.DZ
        return L
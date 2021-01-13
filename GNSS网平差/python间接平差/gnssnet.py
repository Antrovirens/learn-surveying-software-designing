class station(object):
    '''undirected unweighted graph'''

    def __init__(self):
        self.num = int(0)
        self.cat = "未知点"
        self.name = ""
        self.X = 0.0
        self.Y = 0.0
        self.Z = 0.0
        self.N = 0.0
        self.E = 0.0
        self.H = 0.0

        #用来标记是第几个未知点，用来列B矩阵
        self.BeiZhu = int(0)

    def init_station(self,line):
        line = line.rstrip('\n')
        line = line.split(',')

        self.num = int(line[0])
        self.cat = line[1]
        self.name = line[2]

        if self.cat == "已知点":
            self.X = float(line[3])
            self.Y = float(line[4])
            self.Z = float(line[5])
            self.N = float(line[6])
            self.E = float(line[7])
            self.H = float(line[8])


#已经算过近似坐标了
    def init_station2(self,line):
        line = line.rstrip('\n')
        line = line.split(',')

        self.num = int(line[0])
        self.cat = line[1]
        self.name = line[2]

        #
        self.X = float(line[3])
        self.Y = float(line[4])
        self.Z = float(line[5])
        self.N = float(line[6])
        self.E = float(line[7])
        self.H = float(line[8])



    def station_inf(self):
        return [ self.num ,self.name, self.X, self.Y , self.Z , self.cat , self.BeiZhu]

    def station_match(self, point_name):
        if self.name == point_name:
            return True
        else :
            return False

    def cat_match(self):
        if self.cat == "已知点":
            return True
        elif self.cat == "未知点":
            return False
        else:
            return None

    def beizhu(self,i):
        self.BeiZhu = i

    def unknow_num(self):
        return self.BeiZhu




class Baseline(object):
    '''undirected unweighted graph'''

    def __init__(self):
        self.num = int(0)
        self.origin = ""
        self.target = ""
        self.name = ""
        self.DX = 0.0
        self.DY = 0.0
        self.DZ = 0.0
        self.sigema_DX = 0.0
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
        
    def baseline_match(self,baseline):
        if baseline[0] == self.origin and baseline[1] == self.target:
            return True,1,self.num
        elif baseline[0] == self.target and baseline[1] == self.origin:
            return True,-1,self.num
        else:
            return False,0,-1

class GNSSNet(object):
    '''undirected unweighted graph'''

    def __init__(self):

        self.BaselineSet = []

        self.StationSet = []

        self.ControlPts = []
        self.UnknowPts = []

    def insert_Baseline(self,baseline):
        self.BaselineSet.append(baseline)

#初始化站点信息
    def insert_Station(self, station):
        self.StationSet.append(station)

#已知点
    def insert_ControlPoint(self, station):
        self.StationSet.append(station)
#未知点
    def insert_UnknowPoint(self, station):
        self.StationSet.append(station)

    def Net_baseline_match(self,baseline):
        for Baseline in self.BaselineSet:
            a,towards,number = Baseline.baseline_match(baseline)
            if a:
                return towards,self.BaselineSet[number-1].baseline_inf()

    def station_match(self,station_name):
        for station in self.StationSet:
            if station.station_match(station_name):
                return True,station.station_inf()
        return False,None

    def Station_Cat_Match(self,station_name):
        for station in self.StationSet:
            if station.station_match(station_name):
                return True,station.cat_match(),station.station_inf()
        return False,None,None


    def init_P(self,P):
        for Baseline in self.BaselineSet:
            P[Baseline.num*3-3][Baseline.num*3-3] = 1.0 / (Baseline.sigema_DX * Baseline.sigema_DX)
            P[Baseline.num*3-2][Baseline.num*3-2] = 1.0 / (Baseline.sigema_DY * Baseline.sigema_DY)
            P[Baseline.num*3-1][Baseline.num*3-1] = 1.0 / (Baseline.sigema_DZ * Baseline.sigema_DZ)
        return P


    def init_L(self,L):
        for Baseline in self.BaselineSet:
            L[Baseline.num*3-3][0] = Baseline.DX 
            L[Baseline.num*3-2][0] = Baseline.DY
            L[Baseline.num*3-1][0] = Baseline.DZ
        return L

    def init_X0(self,X0):
        for station in self.StationSet:
            if not station.cat_match():
                num = int(station.unknow_num())
                X0[num*3-3][0] = station.X 
                X0[num*3-2][0] = station.Y
                X0[num*3-1][0] = station.Z
                print(station.station_inf()[5] , station.station_inf()[6])
        return X0  
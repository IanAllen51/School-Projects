###
#BDDproject.py by Ian Allen
#CPTS 350
#Notes: Program was tested and run through Command Prompt

from pyeda.inter import *
from pyeda.boolalg.bdd import _NODES

#list of even nodes in graph
evenList = []
#list of prime nodes in graph
primeList = []
#list of all edges in graph represented as tuple (a,b)
pairList = []
#list of all edges in graph represented as a 10 bit string (x = 0-4, y = 5-9)
R = []
#list of all prime to even edges represented as 10 bit binary strings
P2EBin = []
#list of all prime to even edges represented as a tuple(a,b)
primeEvenList = []
#dictionary of nodes and binary string
nodeDict = {}

#helper method for determining if a number is even
def isEven(x):
    if x % 2 == 0:
        return True

#helper method for determining if a number is prime
def isPrime(x):
    if x > 1:
        for num in range(2,x):
            if(x % num) == 0:
                return False
        return True
    else:
        return False

#sort nodes into even and prime lists
def sortNodes(x):
    for nod in range(0,x):
        if (isEven(nod)):
            evenList.append(nod)
        elif (isPrime(nod)):
            primeList.append(nod)

#builds edges based on x+3%32 and x+8%32 condition. edges are converted to binary form
#pairList will then be devided into prime to even pairings with buildPrimeEvenList() method     
def pairFinder(x):
    for first in range(x):
        for second in range(x):
            if(((first+3)%x == second%x) or ((first+8)%x == second%x)):
                pairList.append((first,second))
    convEdgToBin()
    buildPrimeEvenList(pairList)


#convert decimal (node) values into binary representation
def decToBin(x,length):
    build = ''
    bitname = bin(x)
    #bin() function returns string with 0b as first two indecies. Need to remove
    bitname = bitname.replace('0b', '')
    #builds binary string to 5 bit if node is <16
    y = length - len(bitname)
    for num in range(y):
        build += '0'
    bitname = build + bitname
    return bitname


#NOT USED //inteded for dynamically building smaller BDDS ex. 3 == 11 vs 00011
#calculate the minimum number of bits needed
def binLen(x):
    count = 1
    if x == 0: return count
    else: y = x - 1
    while y != 1:
        y = y//2
        count += 1
    return count

#create dictionary of nodes and binary representation.
def buildDict(x):
    bitLength = 5
    for num in range(x):
        nodeDict.update({num : decToBin(num,bitLength)})

#If pair is (prime,even), edge will be added to primeEvenList.After sorting, list will be
#converted to binary representation in p2EBin list
def buildPrimeEvenList(list):
    for x in list:
        if (x[0] in primeList) and (x[-1] in evenList):
            primeEvenList.append(x)
    primeEvenEdgToBin()
    
#sorts and builds even, prime, R, pair, primeEven, and p2EBin Lists. As well as constructs a
#binary dictionary of all nodes
def initializeGraph(x):
    buildDict(x)
    sortNodes(x)
    pairFinder(x)

#use the dictionary of binary node values to build binary edges
def convEdgToBin():
    for x in pairList:
        edgeBin = ''
        for num in x:
            edgeBin += nodeDict[num]
        R.append(edgeBin)

#use the dictionary of binary node values to build binary edges of prime to even nodes
def primeEvenEdgToBin():
    for x in primeEvenList:
        edgeBin = ''
        for num in x:
            edgeBin += nodeDict[num]
        P2EBin.append(edgeBin)


#convert binary string into an expression
def expConv(bin):
    expStr = '(('
    counter = 0
    #strings are 10 bits long, need to separate first 5 into x[] and last 5 into y[]
    # 0 == ~x or ~y, 1 == x or y
    for digit in bin:
        if counter < 5:
            if digit == '0':
                expStr += '~'
            expStr += 'x['+ str(counter) + '] & '
        else:
            if counter == 5:
                expStr = expStr[0:-3] + ') & ('
            if digit == '0':
                expStr += '~'
            expStr += 'y['+ str(counter%5) + '] & '
        counter += 1

    expStr = expStr[0:-3] + '))'
    return expStr

def buildExpression(list):
    expString = ''
    #for each binary edge
    for x in list:
        expString += expConv(x) + " | "
    expString = expString[0:-3]
    return expString

def rCompR(BDD):
    #establish variables to use
    x0,x1,x2,x3,x4 = bddvars('x', 5)
    y0,y1,y2,y3,y4 = bddvars('y', 5)
    z0,z1,z2,z3,z4 = bddvars('z', 5)

    #build lengths for two steps x to z and z to y
    r1 = BDD.compose({x0:z0, x1:z1, x2:z2, x3:z3, x4:z4})
    r2 = BDD.compose({y0:z0, y1:z1, y2:z2, y3:z3, y4:z4})
    #remove the middle node z
    rComR = (r1 & r2).smoothing((z0,z1,z2,z3,z4))
    return rComR

#follow lecture28 for Transitive closure---------------
# H=R
# Repeat
#   H' = H
#   H = H' V (H'compose R)
#   simplify H  ##smoothing
# Until H == H'
# Return H // <- R*
#---------------------vvvvvvvvvv-----------------------

def transClosure(BDD):
    #establish variables to use
    x0,x1,x2,x3,x4 = bddvars('x', 5)
    y0,y1,y2,y3,y4 = bddvars('y', 5)
    z0,z1,z2,z3,z4 = bddvars('z', 5)

    H = BDD
    while (True):
        #HP for H'
        HP = H
        #compose H' and R
        HPComp = HP.compose({y0:z0, y1:z1, y2:z2, y3:z3, y4:z4})
        RComp = BDD.compose({x0:z0, x1:z1, x2:z2, x3:z3, x4:z4})
        # H = H' V (H' comp R)
        #smoothing to simplify
        H = (HP | (HPComp & RComp)).smoothing((z0,z1,z2,z3,z4))

        #check if H == H'
        #if true, return H
        if (H.equivalent(HP)):
            return H


#DRIVER CODE------------------------------------------------------------------

#initialize x and y variables. 5 bit
x0, x1, x2, x3, x4 = bddvars('x', 5)
y0, y1, y2, y3, y4 = bddvars('y', 5)


initializeGraph(32)
print("Node to binary representation")
print(nodeDict)
print()
print("Edges")
print(pairList)
print()
print("Edges from prime to even nodes")
print(primeEvenList)
print() 
test = buildExpression(P2EBin)
print("Prime to Even expression")
print(test)
#BDD for prime to even nodes
p2EBDD = expr2bdd(expr(test))
print()
print('Can any prime node reach an even node in even steps?')
#4.1
rString = buildExpression(R)
rExpression = expr(rString)
RR = expr2bdd(rExpression)
#4.2
RR2 = rCompR(RR)
#4.3
RR2star = transClosure(RR2)
#combining 4.4 and 4.5. Smoothing out all free variables
PE = (RR2star & p2EBDD).smoothing((x0, x1, x2, x3, x4, y0, y1, y2, y3, y4))
print(PE.is_one())
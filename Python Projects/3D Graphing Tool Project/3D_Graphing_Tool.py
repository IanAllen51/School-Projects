import pygame
import random

from pygame.constants import KEYDOWN, K_c, K_d, K_r, K_l

class Key(pygame.sprite.Sprite):
    def __init__(self,xpos,ypos,id):
        super(Key,self).__init__()

        self.colorstring = startColor
        image = pygame.image.load(self.colorstring).convert()
        defaultSize = (50,50)
        image = pygame.transform.scale(image,defaultSize)
        self.image = image

        self.clicked = False
        self.rect = self.image.get_rect()
        self.rect.y = ypos
        self.rect.x = xpos
        
        self.rect.center = [xpos,ypos]
        self.id = id
        self.linkReady = False
        self.links = []
        self.previousColor = startColor

def printNodeCount():
    nodeText = 'n = '+ str(len(key_list))
    nodeFont = pygame.font.SysFont('Calibri',25)
    nodeText = nodeFont.render(nodeText,True,Black)
    nText_width = nodeText.get_width()
    nText_height = nodeText.get_height()
    screen.blit(nodeText, (20,25))
    
def printEdgeCount():
    edgeText = 'm = ' + str(len(edgeTupleList))
    edgeFont = pygame.font.SysFont('Calibri', 25)
    edgeText = edgeFont.render(edgeText,True,Black)
    eText_width = edgeText.get_width()
    eText_height = edgeText.get_height()
    screen.blit(edgeText, (20,55))

def printNodeNum():
    for key in key_list:
        font = pygame.font.SysFont('Calibri',25)
        text = font.render(str(key.id),True,Black)
        text_width = text.get_width()
        text_height = text.get_height()
        screen.blit(text,[key.rect.x,key.rect.y + 50])

def printTotalDegree():
    edgeText = 'Total Degree = ' + str(len(edgeTupleList)*2)
    edgeFont = pygame.font.SysFont('Calibri', 25)
    edgeText = edgeFont.render(edgeText,True,Black)
    eText_width = edgeText.get_width()
    eText_height = edgeText.get_height()
    screen.blit(edgeText, (20,85))

def printNodeDegree():
    edgeText = 'Node Degree: '
    count = 0
    for x in range(1,len(key_list)+1):
        count = 0
        for key in edgeCountList:
            if key[1][0] == x and key[1][1]==x:
                count += key[0]*2
            elif key[1][0] == x or key[1][1] == x:
                count += key[0]
        edgeText += 'Node'+str(x)+':'+str(count)+', '
    edgeFont = pygame.font.SysFont('Calibri', 25)
    edgeText = edgeFont.render(edgeText,True,Black)
    eText_width = edgeText.get_width()
    eText_height = edgeText.get_height()
    screen.blit(edgeText, (20,0))
    



#TESTER
def printEdgeList():
    edgeText = 'edgeList = ' + str(edgeList)
    edgeFont = pygame.font.SysFont('Calibri', 25)
    edgeText = edgeFont.render(edgeText,True,Black)
    eText_width = edgeText.get_width()
    eText_height = edgeText.get_height()
    screen.blit(edgeText, (500,80))

def printEdgePairs():
    tempList = []
    for t in edgeTupleList:
            x = (t[0].id, t[1].id)
            tempList.append(x)
    edgeText = "tupList = " + str(tempList)
    edgeFont = pygame.font.SysFont('Calibri', 25)
    edgeText = edgeFont.render(edgeText,True,Black)
    eText_width = edgeText.get_width()
    eText_height = edgeText.get_height()
    screen.blit(edgeText, (500,110))


def buildIDPairsList():
    tempList = []
    for t in edgeTupleList:
            x = (t[0].id, t[1].id)
            tempList.append(x)
    return tempList

def buildRetList():
    tempList = []
    count = 0
    while count < len(idPairList):
        tempList.append((idPairList.count(idPairList[count]), idPairList[count]))
        count += idPairList.count(idPairList[count])
    #   
    return tempList

def delete(list1):
    l2 = []
    for x in range(len(list1)):
        if list1[x] == key.id:
            l2.append(x)
    l2.reverse()
    for x in l2:
        if x%2 == 0:
            list1.pop(x+1)
            list1.pop(x)
        else:
            list1.pop(x)
            list1.pop(x-1)   

 

Black = (0,0,0)
White = (255,255,255)
Green = (0,255,0)
Red = (255,0,0)
Blue = (0,0,255)
startColor = "White.png"
selectColor = "Black.png"
redNode = "Red.png"
blueNode = "Blue.png"
greenNode = "Green.png"
purpleNode = "Purple.png"
pygame.init()

size = (700,600)
screen = pygame.display.set_mode(size)
pygame.display.set_caption('SketchTest')

done = False

clock = pygame.time.Clock()

key_list = pygame.sprite.Group()
edgeCount = 0
clickCounter = 0
tempNode = []
edgeList = []
idPairList = []
edgeCountList = []
edgeTupleList = []
middleClick = True
removal = False

selected = False

First = Key(0,0,0)
Second = Key(0,0,0)


while not done:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            done = True

        elif event.type == pygame.MOUSEBUTTONDOWN:
            pos = pygame.mouse.get_pos()
            x = pos[0]
            y = pos[1]
            if event.button == 3: #right click
                ##Test
                if clickCounter == 0:
                    key_list.add(Key(x,y,len(key_list) + 1))
            elif event.button == 1:#left click
                #
                singleClicked = False
                #
                for key in key_list:
                    #added singleClicked == False
                    if singleClicked == False and key.rect.collidepoint(pos):
                        key.clicked = True
                        #
                        singleClicked = True
                        #
            elif event.button == 2: #wheel click

                if middleClick == False and clickCounter == 1:
                    for key in key_list:
                        #added id to temp
                        if key.id == tempNode[0].id:
                           
                            key.colorstring = key.previousColor
                            key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(), (50,50))
                            
                            #key.image = pygame.transform.scale(pygame.image.load(key.previousColor).convert(), (50,50))
                            #
                            #key.linkReady = False
                    tempNode.clear()
                    clickCounter = 0
                    middleClick = True
                    ##ADDED
                    

                for key in key_list:
                    if key.rect.collidepoint(pos):
                        key.linkReady = True
                        key.previousColor = key.colorstring
                        key.colorstring = selectColor
                        key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(),(50,50))
       

                        for key in key_list:
                            if key.linkReady == True:
                                clickCounter += 1
                                #tempNode.append(key.id)
                                tempNode.append(key)
                        if clickCounter == 2:
                            for key in key_list:
                                if key.linkReady == True:
                                    key.linkReady = False
                                    key.colorstring = key.previousColor
                                    key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(), (50,50))
                                    clickCounter = 0
                            #edgeList.append(tempNode[0])
                            #edgeList.append(tempNode[1])
                            edgeTupleList.append((tempNode[0],tempNode[1]))
                            tempNode.clear()
                    else:
                        middleClick = False


        
        elif event.type == pygame.MOUSEBUTTONUP:
            for key in key_list:
                key.clicked = False
            drag_id = 0
    
        elif event.type == pygame.KEYDOWN:
            
            if event.key == K_d:
                if key.linkReady == True:
                    removal = True
 
            if event.key == K_r:
                for key in key_list:
                    if key.linkReady == True:
                        #key.previousColor = key.colorString

                        if key.previousColor == startColor:
                            key.colorstring = redNode
                            key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(),(50,50))
                            ##Test
                            key.previousColor = redNode
                            key.linkReady = False
                            clickCounter = 0

                        elif key.previousColor == redNode:
                            key.colorstring = greenNode
                            key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(),(50,50))
                            ##
                            key.previousColor = greenNode
                            key.linkReady = False
                            clickCounter = 0

                        elif key.previousColor == greenNode:
                            key.colorstring = blueNode
                            key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(),(50,50))
                            #
                            key.previousColor = blueNode
                            key.linkReady = False
                            clickCounter = 0

                        elif key.previousColor == blueNode:
                            key.colorstring = purpleNode
                            key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(),(50,50))
                            #
                            key.previousColor = purpleNode
                            key.linkReady = False
                            clickCounter = 0

                        elif key.previousColor == purpleNode:
                            #was set to startColor
                            key.colorstring = redNode
                            key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(),(50,50))
                            #
                            key.previousColor = redNode
                            key.linkReady = False
                            clickCounter = 0

                    
            if event.key == K_l:
                for key in key_list:
                    if key.linkReady == True:
                        #edgeList.append(key.id)
                        #edgeList.append(key.id)
                        edgeTupleList.append((key,key))
                        key.colorstring = key.previousColor
                        key.image = pygame.transform.scale(pygame.image.load(key.colorstring).convert(), (50,50))
                        key.linkReady = False
                        clickCounter = 0
                        middleClick = True
                



            #randomize node positions by key c
            if event.key == K_c:
                for key in key_list:
                    key.rect.x = random.randrange(150,625)
                    key.rect.y = random.randrange(150,525)

    
    if removal == True and key.linkReady == True:
        #delete(edgeList)
        for tup in edgeTupleList:
            if tup[0].id == key.id or tup[1].id == key.id:
                ctr = 0
                while ctr in range(edgeTupleList.count(tup)+1):
                    edgeTupleList.remove(tup)
                    ctr += 1

        #for tup in edgeCountList:
        #    if tup[1][0] == key.id or tup[1][1] == key.id:
        #        edgeCountList.remove(tup)


        key.linkReady = False      
        key_list.remove(key)
        removal = False
        


    #move the vertex
    for key in key_list:
        if key.clicked == True:
            pos = pygame.mouse.get_pos()
            key.rect.x = pos[0] - (key.rect.width/2)
            key.rect.y = pos[1] - (key.rect.height/2)


    screen.fill(White)

    printNodeNum()

    idPairList = buildIDPairsList()
    idPairList.sort()
    #set list of tuples with count and key pair
    edgeCountList = buildRetList()

    for tup in edgeCountList:
        count = tup[0]
        if tup[1][0] == tup[1][1]:
            for pair in edgeTupleList:
                if pair[0].id == tup[1][0] and pair[1].id == tup[1][1]:
                    for x in range(count):
                        pygame.draw.circle(screen,Black,(pair[0].rect.x, pair[1].rect.y),25+(x*3),2)
                        edgeCount += 1
        else:
            for pair in edgeTupleList:
                if pair[0].id == tup[1][0] and pair[1].id == tup[1][1]:
                    for x in range(count):
                        pygame.draw.line(screen,Black,(pair[0].rect.x + (pair[0].rect.width/2), pair[0].rect.y + (pair[0].rect.height/2)+(3*x)), (pair[1].rect.x + (pair[1].rect.width/2), pair[1].rect.y +(pair[1].rect.height/2)+(3*x)),2)
                        edgeCount += 1

    #Test
    pygame.Surface.set_colorkey(pygame.image.load('White.png'),[0,0,0])

    printNodeCount()
    printEdgeCount()
    #printEdgeList()
    #printEdgePairs()
    printTotalDegree()
    printNodeDegree()
    #edgeTupleList.clear()
    edgeCount = 0
    edgeCountList.clear()
    

    key_list.draw(screen)

    pygame.display.flip()
    
    clock.tick(60)

pygame.quit()
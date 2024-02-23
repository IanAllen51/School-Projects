#Ian Allen
#CPTS 327 Computer Security


import os 
#Encryption algorithm
def encryption():
   
    #establish photo to encrypt
    imgPath = input(r'Enter Image Pathway: ')
    if not os.path.exists(imgPath):
        print('File pathway not valid')
    else:
        #generate key
        try: #try block to test if user inputs valid key type
            key = int(input('Enter encryption Key for Image: '))

            print('Image Pathway: ', imgPath)
            print('Encryption Key: ', key)
            fin = open(imgPath,'rb')
            pic = fin.read()
            fin.close()
            #set image to bytes for later manipulation
            pic = bytearray(pic)

            newKey = key + key%7
            for x in range(1,4):
                for index, values in enumerate(pic):
                    pic[index] = values ^ newKey
                newKey = newKey + newKey%(7*x)


            #scramble image bytes with XOR
            #for index, values in enumerate(pic):
            #    #NOTE future developement will increase shifting here
            #    pic[index] = values ^ key

            fin = open(imgPath, 'wb')
            fin.write(pic)
            fin.close()
            print('Image Encrypted\n')
        except(ValueError):
            print('Invalid key type')

def decryption():
    #establish photo to decrypt
    imgPath = input(r'Enter Image Pathway: ')
    if not os.path.exists(imgPath):
        print('File pathway not valid')
    else:
        #generate key
        try: #try block to test if user inputs valid key type
            key = int(input('Enter Decryption Key for Image: '))
            print('Image Pathway: ', imgPath)
            print('Decryption Key: ', key)
            fin = open(imgPath,'rb')
            pic = fin.read()
            fin.close()
            #set image to bytes for later manipulation 
            pic = bytearray(pic)
            keyList = modifyKey(key)
            keyList.reverse()

            for x in keyList:
                for index,values in enumerate(pic):
                    pic[index] = values ^ x


            fin = open(imgPath, 'wb')
            fin.write(pic)
            fin.close()
            print('Image Decrypted\n')
        except(ValueError):
            print('Invalid key type')

def modifyKey(key):
    newKey = key + key%7
    temp = []
    for x in range(1,4):
        temp.append(newKey)
        newKey = newKey + newKey%(7*x)   
    return temp


#main function to call encryption and decryption
def main():
    userSelection = 3
    while userSelection != 0:
        userSelection = int(input('Options:\n\t0 -> Exit\n\t1 -> Image Encryption\n\t2 -> Image Decryption\nWhat action would you like to take? '))
        if userSelection == 0:
            break
        elif userSelection == 1:
            encryption()
        elif userSelection == 2:
            decryption()
        else:
            print('Not a valid answer\n\n')



if __name__=="__main__":
    main()

import json

def cleanStr4SQL(s):
    return s.replace("'","`").replace("\n"," ")

def parseBusinessData():
    #read the JSON file
    # We assume that the Yelp data files are available in the current directory. If not, you should specify the path when you "open" the function. 
    with open('.//yelp_business.JSON','r') as f:  
        outfile =  open('.//business.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            outfile.write("{} - business info : '{}' ; '{}' ; '{}' ; '{}' ; '{}' ; '{}' ; {} ; {} ; {} ; {}\n".format(
                              str(count_line), # the line count
                              cleanStr4SQL(data['business_id']),
                              cleanStr4SQL(data["name"]),
                              cleanStr4SQL(data["address"]),
                              cleanStr4SQL(data["state"]),
                              cleanStr4SQL(data["city"]),
                              cleanStr4SQL(data["postal_code"]),
                              str(data["latitude"]),
                              str(data["longitude"]),
                              str(data["stars"]),
                              str(data["is_open"])) )

            #process business categories
            categories = data["categories"].split(', ')
            outfile.write("      categories: {}\n".format(str(categories)))

            
            # TO-DO : write your own code to process attributes
            # make sure to **recursively** parse all attributes at all nesting levels. You should not assume a particular nesting level. 
            tempList = []
            def recurAttributes(d):
                tempDict = d.items()
                for x,y in tempDict:
                    if isinstance(y,dict):
                        #print(y)
                        recurAttributes(y)
                    else:
                        tempList.append((x,y))
                return tempList


            
            attributes = recurAttributes(data["attributes"])
            outfile.write("      attributes: {}:\n".format(str(attributes))) 

            # TO-DO : write your own code to process hours data
        
            hours = data["hours"]
            hoursUpdate = {key: list(map(str, value.split('-'))) for key, value in hours.items()}
            list_of_hours = list(hoursUpdate.items())
            outfile.write("      hours: {}\n".format(str(list_of_hours))) 

            outfile.write('\n')

            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()

def parseUserData():
    # TO-DO : write code to parse yelp_user.JSON
     #read the JSON file
    # We assume that the Yelp data files are available in the current directory. If not, you should specify the path when you "open" the function. 
    with open('.//yelp_user.JSON','r') as f:  
        outfile =  open('.//user.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            outfile.write("{}- user info: '{}' ; '{}' ; '{}' ; {} ; {} ; {} ; ({},{},{})\n".format(
                              str(count_line), # the line count
                              cleanStr4SQL(data['user_id']),
                              cleanStr4SQL(data['name']),
                              cleanStr4SQL(data['yelping_since']),
                              str(data['tipcount']),
                              str(data['fans']),
                              str(data['average_stars']),
                              str(data['funny']),
                              str(data['useful']),
                              str(data['cool']) ))
            
            
            outfile.write("    friends: {}\n".format(str(data['friends'])))
            #outfile.write('\n')

            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()

    #pass

def parseCheckinData():
    # TO-DO : write code to parse yelp_checkin.JSON
    with open('.//yelp_checkin.JSON','r') as f:
        outfile =  open('.//checkin.txt', 'w')
        line = f.readline()
        count_line = 0
        while line:
            data = json.loads(line)
            outfile.write("'" + cleanStr4SQL(data['business_id'])+ "'" +'\t') #business id
            for tarih in (data["date"].split(",")):
                date = (tarih.split(" "))
                date_list = (date[0].split("-"))
                date_list.append(date[1])
                outfile.write(str(tuple(date_list)))

            #outfile.write(str(date))
            outfile.write('\n')

            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()
    
    #pass


def parseTipData():
    # TO-DO : write code to parse yelp_tip.JSON
    with open('.//yelp_tip.JSON','r') as f:  #Assumes that the data files are available in the current directory. If not, you should set the path for the yelp data files.
        outfile =  open('.//tips.txt', 'w')
        line = f.readline()
        count_line = 0
        count = 1
        while line:
            data = json.loads(line)
            outfile.write(str(count) + '- ')
            outfile.write("'" + str(cleanStr4SQL(data['business_id']))+ "'" + ' ; ') #business_id
            outfile.write("'" + cleanStr4SQL(data['date']) + "'" + ' ; ') #date
            outfile.write("'" + str(data['likes']) + "'" + ' ; ') #date
            outfile.write("'" + str(data['text']) + "'" +' ; ') #text
            outfile.write("'" + str(cleanStr4SQL(data['user_id']) + "'")) #user_id
            outfile.write('\n')
            
            line = f.readline()
            count_line +=1
            count += 1
            
    print(count_line)
    outfile.close()
    f.close()
    #pass

if __name__ == "__main__":
    parseBusinessData()
    parseUserData()
    parseCheckinData()
    parseTipData()

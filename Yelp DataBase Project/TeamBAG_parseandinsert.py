#CptS 451 - Spring 2022
# https://www.psycopg.org/docs/usage.html#query-parameters

#  if psycopg2 is not installed, install it using pip installer :  pip install psycopg2  (or pip3 install psycopg2) 
import json
import psycopg2

def cleanStr4SQL(s):
    return s.replace("'","`").replace("\n"," ")

def int2BoolStr (value):
    if value == 0:
        return 'False'
    else:
        return 'True'



def insert2BusinessTable():
    #reading the JSON file
    with open('milestone2\yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()
        

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the current business
            # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
            # include values for all businessTable attributes
            try:
                cur.execute("INSERT INTO Business (busId, bname, bAddress, bCity, bState, bZip, checkInCount, tipCount, stars, latitude, longitude, isOpen)"
                       + " VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)", 
                         (data['business_id'],cleanStr4SQL(data["name"]), cleanStr4SQL(data["address"]),  data["city"], data["state"], data["postal_code"], 0, 0, data["stars"], data["latitude"], data["longitude"], [False,True][data["is_open"]] ) )              
            except Exception as e:
                print("Insert to Business failed!",e)
            conn.commit()

            #insert into Hours
            try:
                for x in data["hours"].items():
                    lst = x[1].split("-")
                    cur.execute("INSERT INTO Hours (busId, dayOfWeek, openTime, closeTime)"
                       + " VALUES (%s, %s,%s,%s)", 
                         (data['business_id'], x[0], lst[0], lst[1] ) )  
                
            except Exception as e:
                print("Insert to Hours failed!",e)
            conn.commit()

            #insert into Attributes
            def recurAttributes(d):
                for x,y in d.items():
                    if isinstance(y,dict):
                        recurAttributes(y)
                    else:
                        cur.execute("INSERT INTO Attributes (busID, attribute, value)"
                            + " VALUES (%s,%s, %s)",
                              (data['business_id'], x, y))

            try:
                recurAttributes(data["attributes"])
                
            except Exception as e:
                print("Insert to Attributes failed!",e)
            conn.commit()

            #insert into categories
            try:
                for x in data["categories"].split(", "):
                    cur.execute("INSERT INTO Categories (busId, category)"
                       + " VALUES (%s, %s)", 
                         (data['business_id'], x ) )  
                
            except Exception as e:
                print("Insert to Categories failed!",e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Business completed: "+str(count_line))
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2UsersTable():
    #reading the JSON file
    with open('milestone2\yelp_user.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the current business
            # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
            # include values for all businessTable attributes
            try:
                cur.execute("INSERT INTO Users (userId, uname, join_datetime, tipcount, totalFans, avgStars, funnyVotes, coolVotes, usefulVotes)"
                       + " VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s)", 
                         (data["user_id"],cleanStr4SQL(data["name"]), data["yelping_since"], 0, data["fans"], data["average_stars"], data["funny"], data["cool"], data["useful"] ) )              
            except Exception as e:
                print("Insert to Users failed! @"+str(count_line),e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("User completed: "+str(count_line))
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2TipTable():
    with open('milestone2\yelp_tip.JSON','r') as f:
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the current business
            # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
            # include values for all businessTable attributes
            try:
                cur.execute("INSERT INTO tip (busId, userId, tipDate, likes, tipText)"
                       + " VALUES (%s, %s, %s, %s, %s)", 
                         (data["business_id"], data["user_id"], data["date"], 0, cleanStr4SQL(data["text"])  ) )              
            except Exception as e:
                print("Insert to tip failed!",e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Tip completed: "+str(count_line))
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2CheckInTable():
        with open('milestone2\yelp_checkin.JSON','r') as f:    #TODO: update path for the input file
            #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
            line = f.readline()
            count_line = 0

            #connect to yelpdb database on postgres server using psycopg2
            try:
                #TODO: update the database name, username, and password
                conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
            except:
                print('Unable to connect to the database!')
            cur = conn.cursor()

            while line:
                data = json.loads(line)
                # Generate the INSERT statement for the current business
                # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
                # include values for all businessTable attributes
                try:
                    for x in (data["date"].split(",")):
                        date = (x.split(" "))
                        date_list = (date[0].split("-"))
                        cur.execute("INSERT INTO checkIn (busId, year, month, day, time)" + " VALUES (%s,%s,%s,%s,%s)",
                            (data["business_id"],date_list[0], date_list[1], date_list[2], date[1]))             
                except Exception as e:
                    print("Insert to Business failed!",e)
                conn.commit()
                # optionally you might write the INSERT statement to a file.
                # sql_str = ("INSERT INTO businessTable (business_id, name, address, state, city, zipcode, latitude, longitude, stars, numCheckins, numTips, is_open)"
                #           + " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11})").format(data['business_id'],cleanStr4SQL(data["name"]), cleanStr4SQL(data["address"]), data["state"], data["city"], data["postal_code"], data["latitude"], data["longitude"], data["stars"], 0 , 0 , [False,True][data["is_open"]] )            
                # outfile.write(sql_str+'\n')

                line = f.readline()
                count_line +=1

            cur.close()
            conn.close()

        print("CheckIn completed: "+str(count_line))
        #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
        f.close()

def insert2FriendTable():
    #reading the JSON file
    with open('milestone2\yelp_user.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            
            #load friend table
            try:
                for x in data["friends"]:
                    cur.execute("INSERT INTO Friend (userId, friendId)"
                       + " VALUES (%s, %s)", 
                         (data['user_id'], x) )
                            
            except Exception as e:
                print("Insert to Friend failed!",e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Friend completed: "+str(count_line))
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2HourTable():
    #reading the JSON file
    with open('milestone2\yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)

            #insert into Hours
            try:
                for x in data["hours"].items():
                    lst = x[1].split("-")
                    cur.execute("INSERT INTO Hours (busId, dayOfWeek, openTime, closeTime)"
                       + " VALUES (%s, %s,%s,%s)", 
                         (data['business_id'], x[0], lst[0], lst[1] ) )  
                
            except Exception as e:
                print("Insert to Hours failed!",e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()


def insert2AttributesTable():
    #reading the JSON file
    with open('milestone2\yelp_business.JSONN','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)

            #insert into Attributes
            def recurAttributes(d):
                for x,y in d.items():
                    if isinstance(y,dict):
                        recurAttributes(y)
                    else:
                        cur.execute("INSERT INTO Attributes (busID, attribute, value)"
                            + " VALUES (%s,%s, %s)",
                              (data['business_id'], x, y))

            try:
                recurAttributes(data["attributes"])
                
            except Exception as e:
                print("Insert to Attributes failed!",e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2CategoriesTable():
    #reading the JSON file
    with open('milestone2\yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='**********'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            
            #insert into categories
            try:
                for x in data["categories"].split(", "):
                    cur.execute("INSERT INTO Categories (busId, category)"
                       + " VALUES (%s, %s)", 
                         (data['business_id'], x ) )  
                
            except Exception as e:
                print("Insert to Categories failed!",e)
            conn.commit()

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()
if __name__ == "__main__":
    insert2BusinessTable()
    #insert2CategoriesTable()
    #insert2AttributesTable()
    #insert2HourTable()
    insert2UsersTable()
    insert2FriendTable()
    insert2CheckInTable()
    insert2TipTable()
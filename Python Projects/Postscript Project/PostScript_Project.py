#Ian Allen CptS355 HW4 and HW5
#
#
# The operand stack: define the operand stack and its operations

opstack = []  #assuming top of the stack is the end of the list

# Now define the helper functions to push and pop values on the opstack
# (i.e, add/remove elements to/from the end of the Python list)
# Remember that there is a Postscript operator called "pop" so we choose
# different names for these functions.

def opPop():
    if opstack == []:
        print("Empty stack.")
        return
    return opstack.pop()
    
    # opPop should return the popped value.
    # The pop() function should call opPop to pop the top value from the opstack, but it will ignore the popped value.

def opPush(value):
    opstack.append(value)


# The dictionary stack: define the dictionary stack and its operations

dictstack = []  #assuming top of the stack is the end of the list

# now define functions to push and pop dictionaries on the dictstack, to
# define name, and to lookup a name

def dictPop():
    if dictstack == []:
        print("Empty stack.")
        return
    return dictstack.pop()
    # dictPop pops the top dictionary from the dictionary stack.

def dictPush(d):
    dictstack.append(d)
    
    #dictPush pushes the dictionary ‘d’ to the dictstack.
    #Note that, your interpreter will call dictPush only when Postscript
    #“begin” operator is called. “begin” should pop the empty dictionary from
    #the opstack and push it onto the dictstack by calling dictPush.

def define(name, value):
    if len(dictstack) == 0:
        dictPush({})
    dictstack[-1].update({name:value})

    #add name:value pair to the top dictionary in the dictionary stack.
    #Keep the '/' in the name constant.
    #Your psDef function should pop the name and value from operand stack and
    #call the “define” function.

def lookup(name):
    x = "/" + name
    indx = len(dictstack)
    neg = -1
    indx *= neg
    indx -= 1
    while neg > indx:
        if x in dictstack[neg]:
            return dictstack[neg].get(x)
        neg -= 1
    if neg == indx:
        x = name + " is not in dictionary"
        return x
    # return the value associated with name


# Arithmetic and comparison operators: add, sub, mul, div, mod, eq, lt, gt
# Make sure to check the operand stack has the correct number of parameters
# and types of the parameters are correct.
def add():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str or type(opstack[-2]) == str:
        return "Incorrect types"
    if type(opstack[-1]) == bool or type(opstack[-2]) == bool:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x + y)

def sub():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str or type(opstack[-2]) == str:
        return "Incorrect types"
    if type(opstack[-1]) == bool or type(opstack[-2]) == bool:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x - y)

def mul():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str or type(opstack[-2]) == str:
        return "Incorrect types"
    if type(opstack[-1]) == bool or type(opstack[-2]) == bool:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x * y)

def div():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str or type(opstack[-2]) == str:
        return "Incorrect types"
    if type(opstack[-1]) == bool or type(opstack[-2]) == bool:
        return "Incorrect types"
    if opstack[-1] == 0:
        return "No dividing by zero"
    y = opPop()
    x = opPop()
    opPush(x / y)


def mod():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) != int and type(opstack[-2]) != int:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x % y)

def eq():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str and type(opstack[-2]) != str or type(opstack[-2]) == str and type(opstack[-1]) != str:
        return "Incorrect types"
    if type(opstack[-1]) == bool and type(opstack[-2]) != bool or type(opstack[-2]) == bool and type(opstack[-1]) != bool:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x == y)

def lt():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str and type(opstack[-2]) != str or type(opstack[-2]) == str and type(opstack[-1]) != str:
        return "Incorrect types"
    if type(opstack[-1]) == bool and type(opstack[-2]) != bool or type(opstack[-2]) == bool and type(opstack[-1]) != bool:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x < y)

def gt():
    if len(opstack) < 2:
        return "Too few operands"
    if type(opstack[-1]) == str and type(opstack[-2]) != str or type(opstack[-2]) == str and type(opstack[-1]) != str:
        return "Incorrect types"
    if type(opstack[-1]) == bool and type(opstack[-2]) != bool or type(opstack[-2]) == bool and type(opstack[-1]) != bool:
        return "Incorrect types"
    y = opPop()
    x = opPop()
    opPush(x > y)


# String operators: define the string operators length, get, getinterval, put
def length():
    if type(opstack[-1]) != str:
        return "Not string class"
    x = len(opstack[-1]) - 2
    opPop()
    opPush(x)


def get():
    if len(opstack) < 2:
        return "Too few items on stack"
    if type(opstack[-1]) != int:
        return "Need an int on top of stack"
    if type(opstack[-2]) != str:
        return "String needs to be second from the top of stack"
    x = opPop() + 1
    temp = opPop()
    if x <= len(temp) - 2:
        y = temp[x]
        opPush(ord(y))
    else:
        opPush(temp)
        opPush(x - 1)
        return "Integer is out of range"
  


def getinterval():
    if len(opstack) < 3:
        return "Too few items on stack"
    if type(opstack[-2]) != int and type(opstack[-1]) != int:
        return "Need two ints on top of stack"
    if type(opstack[-3]) != str:
        return "String needs to be three from the top of stack"
    count = opPop()
    start = opPop() + 1
    text = opPop()
    final = start + count
    if final > len(text) - 2:
        opPush(text)
        opPush(start - 1)
        opPush(count)
        return "Out of Range"
    newText = "("
    for x in range(start,final):
        newText += text[x]
    newText += ")"
    opPush(newText)
    

def put():
    if len(opstack) < 3:
        return "Too few items on stack"
    if type(opstack[-2]) != int and type(opstack[-1]) != int:
        return "Need two ints on top of stack"
    if type(opstack[-3]) != str:
        return "String needs to be three from the top of the stack"
    asciiVal = opPop()
    if asciiVal < 32 or asciiVal > 126:
        opPush(asciiVal)
        return "Ascii value is out of appropriate range"
    index = opPop() + 1
    origString = opPop()
    if index > len(origString) - 2:
        opPush(origString)
        opPush(index)
        opPush(asciiVal)
        return "Index is out of range of string"
    altString = origString
    altString = altString[:index] + chr(asciiVal) + altString[index+1:]
    counter = 0
    for x in opstack:
        if x == origString:
            opstack[counter] = altString
        counter += 1
    ##ADDED
    if origString in dictstack[-1].values():
        for x in dictstack[-1].keys():
            if dictstack[-1][x] == origString:
                dictstack[-1][x] = altString
    

# Define the stack manipulation and print operators: dup, copy, pop, clear, exch, roll, stack
def dup():
    if len(opstack) > 0:
        opPush(opstack[-1])
    else:
        return "Can not duplicate Empty stack"

def copy():
    nCopy = opPop()
    if nCopy > len(opstack):
        opPush(nCopy)
        return "Copy length larger than stack length"
    copyList = []
    for x in opstack[-nCopy:]:
        copyList.append(x)
    for x in copyList:
        opPush(x)
    
def pop():
    opPop()

def clear():
    opstack.clear()

def exch():
    if len(opstack) < 2:
        return "Too Few arguments on stack to exchange"
    topVal = opPop()
    secondVal = opPop()
    opPush(topVal)
    opPush(secondVal)

def roll():
    if len(opstack) < 3:
        return "Too few items on stack"
    if type(opstack[-2]) != int and type(opstack[-1]) != int:
        return "Need two ints on top of stack"
    index = opPop()
    range = opPop()
    tempList = []
    if range > len(opstack):
        opPush(range)
        opPush(index)
        return "Range is larger than stack"
    if index >= 0:
        for x in opstack[opstack[len(opstack)-range-1]:]:
            tempList.append(x)
        modulus = index % range
        counter = 0
        while counter < modulus:
            lastIndex = tempList.pop()
            tempList.insert(0,lastIndex)
            counter += 1
        updateCounter = len(opstack)-range
        counter = 0
        for x in opstack[opstack[len(opstack)-range-1]:]:
            opstack[updateCounter] = tempList[counter]
            updateCounter += 1
            counter += 1
    if index < 0:
        for x in opstack[opstack[len(opstack)-range-1]:]:
            tempList.append(x)
        modulus = (0-index) % range
        counter = 0
        while counter < modulus:
            firstVal = tempList.pop(0)
            tempList.append(firstVal)
            counter += 1
        updateCounter = len(opstack)-range
        counter = 0
        for x in opstack[opstack[len(opstack)-range-1]:]:
            opstack[updateCounter] = tempList[counter]
            updateCounter += 1
            counter += 1

def stack():
    displayStack = opstack[::-1]
    for x in displayStack:
        print(x)


# Define the dictionary manipulation operators: psDict, begin, end, psDef
# name the function for the def operator psDef because def is reserved in Python. Similarly, call the function for dict operator as psDict.
# Note: The psDef operator will pop the value and name from the opstack and call your own "define" operator (pass those values as parameters).
# Note that psDef()won't have any parameters.

def psDict():
    if type(opstack[-1]) != int:
        return "Need an initalizing value on top of stack"
    pop()
    opPush({})

def begin():
    if type(opstack[-1]) != dict:
        return "No Dict on top of stack"
    tempDict = opPop()
    dictPush(tempDict)

def end():
    if len(dictstack) == 0:
        return "Noting to remove from dictstack"
    dictPop()

def psDef():
    if len(opstack) < 2:
        return "Not enough operands on stack to define"
    if type(opstack[-2]) != str:
        return "Second from top needs to be a string to define."
    if opstack[-2][0] != "/":
        return "String needs to start with / to define variable"
    defValue = opPop()
    defName = opPop()
    define(defName,defValue)


import re
def tokenize(s):
    return re.findall("/?[a-zA-Z()][a-zA-Z0-9_()]*|[-]?[0-9]+|[}{]+|%.*|[^ \t\n]", s)


# The it argument is an iterator.
# The sequence of return characters should represent a list of properly nested
# tokens, where the tokens between '{' and '}' is included as a sublist. If the
# parenteses in the input iterator is not properly nested, returns False.

def groupMatching2(it):
    res = []
    for c in it:
        if c == '}':
            return res
        elif c=='{':
            # Note how we use a recursive call to group the tokens inside the
            # inner matching parenthesis.
            # Once the recursive call returns the code array for the inner
            # paranthesis, it will be appended to the list we are constructing
            # as a whole.
            res.append(groupMatching2(it))
        else:
            res.append(c)
    return False


# Function to parse a list of tokens and arrange the tokens between { and } braces
# as code-arrays.
# Properly nested parentheses are arranged into a list of properly nested lists.

def parse(L):
    ##ADDED. set all possible strings of ints into int variables
    parseCounter = 0 #iteration counter to cycle through list of strings.
    for val in L:
        if val.isdigit():
            L[parseCounter] = int(val) #if string is a number, convert to int and place back into list.
        if val.lstrip('-').isdigit(): #check if string is a negative number, if so, convert to int and place back into list.
            L[parseCounter] = int(val)
        parseCounter += 1
    res = []
    it = iter(L)
    for c in it:
        if c=='}':  #non matching closing paranthesis; return false since there is
                    # a syntax error in the Postscript code.
            return False
        elif c=='{':
            res.append(groupMatching2(it))
        else:
            res.append(c)
    return res


#Helper method for operations
#Holds the operations that can be run by postfix

operationList = ["add", "sub","mul","div","mod","eq","lt","gt","length","get","stack","dict","begin","end","def",
"getinterval","put","dup","copy","pop","clear","exch","roll"]


#helper method to reduce code and give direct functionality to the opertion that was read

def operatorRead(text):
    if text == "add":
        add()
    if text == "sub":
        sub()
    if text == "mul":
        mul()
    if text == "div":
        div()
    if text == "mod":
        mod()
    if text == "eq":
        eq()
    if text == "lt":
        lt()
    if text == "gt":
        gt()
    if text == "length":
        length()
    if text == "get":
        get()
    if text == "stack":
        stack()
    if text == "dict":
        psDict()
    if text == "begin":
        begin()
    if text == "end":
        end()
    if text == "def":
        psDef()
    if text == "getinterval":
        getinterval()
    if text == "put":
        put()
    if text == "dup":
        dup()
    if text == "copy":
        copy()
    if text == "pop":
        pop()
    if text == "clear":
        clear()
    if text == "exch":
        exch()
    if text == "roll":
        roll()

#if operator pops a code array and bool value. if bool is true, perform interpretSPS to implement the code array
def psIf():
    codeTrue = opPop()
    truthVal = opPop()
    if truthVal == True:
        interpretSPS(codeTrue)

#ifelse opertor pops top two code arrays and a bool value. if bool is true, interprestSPS the second popped array, else interpretSPS first popped array
def psIfelse():
    codeFalse = opPop()
    codeTrue = opPop()
    truthVal = opPop()
    if truthVal == True:
        interpretSPS(codeTrue)
    else:
        interpretSPS(codeFalse)

#for operator pops the top code array, then pops final value, increment value, and start value respectively. if start is larger than final,
# perform a while loop that decrements each itertion until less than start. each itertion will push the start value on stack, perform code array
# pushed value, then increments start value by increment value. same process for if start is smaller than final, except increase with each iteration.

def psFor():
    codeArray = opPop()
    finalIndex = opPop()
    increment = opPop()
    startIndex = opPop()
    if startIndex < finalIndex:
        while startIndex <= finalIndex:
            opPush(startIndex)
            interpretSPS(codeArray)
            startIndex += increment
    else:
        while startIndex >= finalIndex:
            opPush(startIndex)
            interpretSPS(codeArray)
            startIndex += increment


def interpretSPS(code): # code is a code array
    for item in code:
        if item in operationList: #checks if item is an operator
             operatorRead(item)   #method will perfrom operator action on stack.
        elif item == "if" or item == "ifelse" or item == "for": #check if item is if/ifelse/or for operation
            if item == "if":
                psIf() 
            elif item == "ifelse":
                psIfelse()
            else:           #can only be for opertion if not if/ifelse
                psFor()
        elif type(item) == int: #check if item is int value
             opPush(item)
        elif type(item) == list: #check if is code array
             opPush(item)
        elif item[0] == "/" or item[0] == "(": #check if item is a definition or a string.
             opPush(item)
        else:   #item has to belong to a definition in the dictstack.
            if type(lookup(item)) != list: #check if is code array, if not, push the value of the variable onto the opstack
                opPush(lookup(item))
            else:
                newCode = lookup(item) #store list (code array) in new variable and run interpretSPS with new variable to implement array
                interpretSPS(newCode)


def interpreter(s): # s is a string
    interpretSPS(parse(tokenize(s)))


#clear opstack and dictstack
def clear():
    del opstack[:]
    del dictstack[:]


#testing

input1 = """
        /square {
               dup mul
        } def 
        (square)
        4 square 
        dup 16 eq 
        {(pass)} {(fail)} ifelse
        stack 
        """

input2 ="""
    (facto) dup length /n exch def
    /fact {
        0 dict begin
           /n exch def
           n 2 lt
           { 1}
           {n 1 sub fact n mul }
           ifelse
        end 
    } def
    n fact stack
    """

input3 = """
        /fact{
        0 dict
                begin
                        /n exch def
                        1
                        n -1 1 {mul} for
                end
        } def
        6
        fact
        stack
    """

input4 = """
        /lt6 { 6 lt } def 
        1 2 3 4 5 6 4 -3 roll    
        dup dup lt6 {mul mul mul} if
        stack 
        clear
    """

input5 = """
        (CptS355_HW5) 4 3 getinterval 
        (355) eq 
        {(You_are_in_CptS355)} if
         stack 
        """

input6 = """
        /pow2 {/n exch def 
               (pow2_of_n_is) dup 8 n 48 add put 
                1 n -1 1 {pop 2 mul} for  
              } def
        (Calculating_pow2_of_9) dup 20 get 48 sub pow2
        stack
        """

print(tokenize(input1))
print(parse(tokenize(input1)))

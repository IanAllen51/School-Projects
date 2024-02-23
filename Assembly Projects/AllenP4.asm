#-----------------------------------------------------------------------------------------------------------------
#AllenP4.asm
#program will caluculate the length of a user defined string
#
#Testing Results:
# 	Initial testing with a hardcoded string "abcdef" resulted in a correct return of 6
# 	Second test with hardcoded string "" return correct value of 0, indicating the branch at the start of the StrLen worked correctly
# 	First test after implementing user input "abc" resulted in return value of 4. After debugging, i found that the return carriage (\n)
# 	was being counted in the recursion.
# 	Second test with same string returned correct value after setting the numcounter to -1 to account for \n.
# 	Third test returned correct value of 0 with "".
#-----------------------------------------------------------------------------------------------------------------


#constants
.eqv PRINT_INT	1
.eqv PRINT_STR 	4
.eqv TERMINATE	10
.eqv READ_STR	8

	.data
Prompt_str:	.asciiz "Please enter a word: "
Close_str: 	.asciiz "Your word has a length: "
Test:		.asciiz ""	#sring constant used to test program
String: 	.space 64	#create a space for input string

	.text
main:

	#print the user prompt
	la $a0, Prompt_str
	li $v0, PRINT_STR
	syscall
	
	#store user input
	la $a0, String		#load the address of the allocated space for user string
	li $a1, 64
	li $v0, READ_STR
	syscall
	
	#run StrLen
	jal StrLen
	
	#store StrLen value in new register
	move $a1, $v0
	
	#print closing message
	la $a0, Close_str
	li $v0, PRINT_STR
	syscall
	
	#print numcount
	move $a0, $a1
	li $v0, PRINT_INT
	syscall
	
	#end program
	li $v0, TERMINATE
	syscall
	
	
	
#-----------------------------------------------------------------------------------------------------------------	
#StrLen- program will take a string and return the length
#Parameters:
#	$a0: contains the address of the space allocated for user input
#Return Value:
#	$v0: returns the numcount of the string length
#Additional Registers Used:
#	$a1: acts as the numcounter for each char in string
#	$t1: contains the value at each element of the string
#	$sp: stack pointer will be changed with each recursion to store location of previous $ra on stack
#

StrLen:
	li $a1, -1	#0	#initiallize numcounter to -1 to account for carriage return at the end of input
	lb $t1, ($a0)		#load the first char of the string into t1
	bne $t1, $0, RunStrLen	#if char is not equal to null, run recursion
	li $v0, 0		#if char is equal to null. load return with 0
	jr $ra
	
RunStrLen:
	bne $t1, $0, Continue	#if char is not equal to null, continue recursion
	move $v0, $a1		#load numcount into return register
	jr $ra
	
Continue:
	addi $sp, $sp, -4	#allocate word of memory on stack
	addi $a0, $a0, 1	#increment String by one char
	lb $t1, ($a0)		#load next char into t1
	addi $a1, $a1, 1	#increment numcount by 1
	sw $ra ($sp)		#store return address
	
	jal RunStrLen
	
	lw $ra ($sp)		#retrieve return address
	addi $sp, $sp, 4	#deallocate word from stack
	jr $ra
	
#-----------------------------------------------------------------------------------------------------------------		
	
	
	
	
	

#AllenP2.asm
#
# Program calls a subroutine to caluculate the product of two
# vectors. The subroutine will use pointers to access individual 
# registers and index.

#constants
.eqv PRINT_INT 1
.eqv PRINT_STR 4
.eqv TERMINATE 10
.eqv PRINT_CHAR 11
.eqv NL 10

	.data
VectorOne: .word 2, 6, 2
VoneEnd: .word 0
VectorTwo: .word 4, -3, 5
VtwoEnd: .word 0
VectorThree: .word 5, 15, 5
VthreeEnd: .word 0

Result_str: .asciiz "The Dot Product of the vecotors is: "
Perp_str: .asciiz " The two vectors are Perpendicular."
NotPerp_str: .asciiz " The two vectors are NOT Perpendicular."

	.text

# Need to load vector one and two into variables
	la $a0, VectorOne
	la $a1, VectorTwo
	la $a2, VoneEnd 
	
#establish the count of the vector
	sub $a2, $a2, $a0	#subtract the largest memory location from the smallest and store in $a2. gives total size of memory
	srl $a2, $a2, 2		#shift right logical $a2 by 2, essentially divides total memory by 4 bytes giving total num count
	
	
#call the dotproduct function
	jal DotProduct

#store dotprod value accumulated in v0 into a a3 for a temp holding
	move $a3, $v0
	
#print the results string
	la $a0, Result_str
	li $v0, PRINT_STR
	syscall

#print dotprod value
	move $a0, $a3
	li $v0, PRINT_INT
	syscall

#Print if perp or not
	beq $a3, $0, Perp		#if the return value from dotprod is 0, print perp. if not, print not perp. 
	la $a0, NotPerp_str
	li $v0, PRINT_STR
	syscall	
	b Continue

Perp:
	la $a0, Perp_str
	li $v0, PRINT_STR
	syscall		

#print space
Continue:								
	li $a0, NL
	li $v0, PRINT_CHAR
	syscall

# Need to load vector one and three into variables
	la $a0, VectorOne
	la $a1, VectorThree
	la $a2, VoneEnd 
	
#establish the count of the vector
	sub $a2, $a2, $a0	#see first call
	srl $a2, $a2, 2		#see first call
	
	
#call the dotproduct function
	jal DotProduct

#store dotprod value accumulated in v0 into a a3 for a temp holding
	move $a3, $v0
	
#print the results string
	la $a0, Result_str
	li $v0, PRINT_STR
	syscall
#print result value
	move $a0, $a3
	li $v0, PRINT_INT
	syscall

#Print if perp or not
	beq $a3, $0, Perp		#see first call for Perp label.
	la $a0, NotPerp_str
	li $v0, PRINT_STR
	syscall	
	b End

#Print space
End:								
	li $a0, NL
	li $v0, PRINT_CHAR
	syscall
	
#end program
	li $v0, TERMINATE
	syscall


#DOTPRODUCT
#calculate the product of two vectors at each index. Add the products together. Loop through
#until all numbers in each vector have been utilized
#Parameters used:
#  $a0 will contain the address of the first vector of numbers
#  $a1 will contain the address of the second vector in the first iteration and third vector in the second.
#  $a2 will contain the num count of both(assumed) vectors and will be used as a control for the loop in the subroutine
#Return Value:
#  $v0 will contain the sum of all the vector products.Value will be zeroed at start of routine and sum will be returned to main
#addition Registers Used:
#  $t0 will act as a loop counter to be compared with the total num count in $a2 to run/end the routine
#  $t1 will be the register that holds the vector product of each iteration. will be added to $v0 to sum the total product
#  $t2 will contain the value of the dereferenced register of vector one
#  $t3 will contain the value of the dereferenced register of vector two on the first iteration and vector three on the second.

DotProduct:
	li $v0, 0	#zero out the return value to store dotproduct sum
	
	li $t0, 1	#t0 will act as a loop counter
	li $t1, 0	#t1 will act as a location of the product of each iteration of dotprod
	
Loop:
	lw $t2, ($a0)		#get the value from the first vector
	lw $t3, ($a1)		#get the value from the second vector
	mul $t1, $t2, $t3	#multiply the given values of both vectors together and store in t1
	add $v0, $v0, $t1	#add the product of both vectors to the sum value in v0
	beq $t0, $a2, Done	#check range to see if loop count is less than num count in a2

	addi $t0, $t0, 1	#increment the loop counter by 1
	addi $a0, $a0, 4	#increment address in vector one by 4 bytes to the next value
	addi $a1, $a1, 4	#increment address in vector two by 4 bytes to the next value 
	b Loop
Done:
	jr $ra			#return to main

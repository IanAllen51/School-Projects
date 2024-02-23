#AllenP3.asm
#
#This program will calculate the sum of a given row and will be able to return the value of a given coordinate in a M X N Matrix.

 #Constants
 .eqv NUM_ROWS	5
 .eqv NUM_COLS	6
 .eqv ELEMENT_SIZE 4
 
 .eqv PRINT_INT 1
 .eqv PRINT_STR 4
 .eqv READ_INT 	5 
 .eqv TERMINATE	10
 .eqv PRINT_CHAR 11
 .eqv NL 10
 
 	.data
 Input_Row_str: .asciiz "Enter the Row number, 0-"
 Input_Col_str: .asciiz "Enter the Column number, 0-"
 Semicolon_str: .asciiz ": "
 Sum_str: 	.asciiz "Sum of the elements of the selected Row: "
 Location_str:	.asciiz "The value at the given location: "
 
 Matrix:
 row0:	.word 1, 6, 8, 10, 12, 2
 row1: 	.word 14, 2, 18, 20, 24, 3
 row2: 	.word 30, 32, 3, 10, 5, 4
 row3: 	.word 1, 2, 3, 4, 5, 5
 row4:	.word 10, 15, 20, 5, 6, 6
 
 RowAddresses: 	.word row0, row1, row2, row3, row4
  
 	.text
 main:
 
 	#Prompt user for row number
 	la $a0, Input_Row_str
 	li $v0, PRINT_STR
 	syscall
 	
 	li $a0, NUM_ROWS
 	addi $a0, $a0, -1		#decrement number of rows by 1 to be 0-based
 	li $v0, PRINT_INT
 	syscall
 	
 	la $a0, Semicolon_str
 	li $v0, PRINT_STR
 	syscall
 	
 	li $v0, READ_INT		#User input for row number
 	syscall
 	
 	#Load input and constants into registers
 	move $a3, $v0			#Store user input in $a3
 	la $a0, Matrix			#Load Matrix address
 	li $a1, NUM_COLS
 	li $a2, NUM_ROWS
 	li $t1, ELEMENT_SIZE
 	
 	#Calculate the starting address of the input row
 	mul $t2, $a1, $t1		#calculate the stride of each row column num x element size in $t2
 	mul $t3, $t2, $a3		#caluculate the byte offset to the row input in $t3
 	add $a0, $a0, $t3		#addres of the first element of the input row in $a0
 
 	#Call the RowSum
 	jal RowSum 
 	
 	#store RowSum Value
 	move $a1, $v0
 	
 	#Print results
 	la $a0, Sum_str
 	li $v0, PRINT_STR
 	syscall
 	
 	move $a0, $a1
 	li $v0, PRINT_INT
 	syscall
 	
 	#-----------------------------------------------------------------------------------------------------
 	#Create spacing
 	li $a0, NL
 	li $v0, PRINT_CHAR
 	syscall
 	syscall
 	
 	
 	#Prompt user for row number
 	la $a0, Input_Row_str
 	li $v0, PRINT_STR
 	syscall
 	
 	li $a0, NUM_ROWS
 	addi $a0, $a0, -1
 	li $v0, PRINT_INT
 	syscall
 	
 	la $a0, Semicolon_str
 	li $v0, PRINT_STR
 	syscall
 	
 	li $v0, READ_INT		#User input for row number
 	syscall
 	
 	#store row in register
 	move $a1, $v0			#store row input in $a1
 	
 	#Prompt user for column number
 	la $a0, Input_Col_str
 	li $v0, PRINT_STR
 	syscall
 	
 	li $a0, NUM_COLS
 	addi $a0, $a0, -1		#decrement number of columns by 1 to be 0-based
 	li $v0, PRINT_INT
 	syscall
 	
 	la $a0, Semicolon_str
 	li $v0, PRINT_STR
 	syscall
 	
 	li $v0, READ_INT		#User input for column number
 	syscall
 	
 	#store column in register
 	move $a2, $v0			#store column input in $a2
 	
 	#Allocate memory on the stack
 	la $a3, Matrix			#Load Matrix address
 	addi $sp, $sp, -8		#allocating memory on the stack
 	sw $a3, ($sp)			#Matrix address in stack pointer 0
 	sw $a1, 4($sp)			#Num Rows stored in stack pointer 0+4
 	sw $a2, 8($sp)			#num Cols stored in stack pointer 0+8
 	
 	#call MatElement
 	jal MatElement
 	
 	move $a1, $v0			#store returned MatElement return value in $a1
 	
 	#deallocate memory
 	addi $sp, $sp, 8
 	
 	#print results
 	la $a0, Location_str
 	li $v0, PRINT_STR
 	syscall
 	
 	move $a0, $a1
 	li $v0, PRINT_INT
 	syscall
 	
 	#End Program
 	li $v0, TERMINATE
 	syscall
 	
 #-----------------------------------------------------------------------------------------------------	
 #RowSum- Calculates the sum of a given row of elements of a matrix
 #Parameters:
 #	$a0: The address of the first element of the desired row
 #	$a1: The number of columns in the Matrix
 #Return:
 #	$v0: will contain the sum of the elements in the specified row
 #Other Registers Used:
 #	$t0: Contains the loop counter
 #	$t1: Contains the address of the first element in the specified row
 #	$t2: Contains the value of the given element in each iteration 
 #
 RowSum:
 	move $t0, $0			#loop counter
 	move $v0, $0			#zero out accumulator
 	move $t1, $a0			#store address of first element in $t1
 Loop:
 	beq $t0, $a1, Done		#Loop ends if loop counter == column count
 	lw $t2, ($t1)			#load the value of the row at the given element
 	add $v0, $v0, $t2		#add element value to the accumulator
 	add $t1, $t1, ELEMENT_SIZE	#increment current element to the next element
 	addi $t0, $t0, 1		#increment loop counter
 	b Loop
 Done:
 	jr $ra				#return to main
 
 
 #-----------------------------------------------------------------------------------------------------
 #MatElement- Finds the value of an element within the matrix with inputs row and col passed on the stack 
 #Parameters:
 #	($sp): Stack pointer contains the address of the first element of the matrix
 #	4($sp): Stack pointer +4 contains the user input for rows
 #	8($sp): Stack pointer +8 contains the user input for cols
 #Return:
 #	$v0: will contain the value within the matched element
 #Other Registers/Constants used within the function
 #	NUM_COLS: Constant value for number of columns in matrix
 #	ELEMENT_SIZE: Constant value for the byte size of each element
 #	$t0: Holds the address of the first element of MATRIX
 #	$t1: Holds the user input value for row number 
 #	$t2: Holds the user input value for column number
 #	$t3: The stride length of each row(byte size * number of columns)
 #	$t4: The offset to the first element of the user input row
 #	$t5: The offset of the user input column on the input row
 #	$t6: Contains the value of NUM_COLS
 #
 MatElement:
 	move $v0, $0			#zero out the return parameter
 	lw $t0, ($sp)			#store the matrix address in $t0
 	lw $t1, 4($sp)			#store value of row input in $t1
 	lw $t2, 8($sp)			#store value of col input in $t2
 	
 	li $t6, NUM_COLS
 	mul $t3, $t6, ELEMENT_SIZE	#generate stride length per row
 	mul $t4, $t1, $t3		#generate offset for starting position of input row
 	add $t0, $t0, $t4		#sets the address to the first element of the input row
 	mul $t5, $t2, ELEMENT_SIZE	#generates offset for the position of the input column in the row
 	add $t0, $t0, $t5		#sets the address to the matching element
 	lw $v0, ($t0)			#load return register with the value in the matched element
 	
 	jr $ra   			#return to main
 
 #-----------------------------------------------------------------------------------------------------
 
 
 
 
 
 
 
 
 
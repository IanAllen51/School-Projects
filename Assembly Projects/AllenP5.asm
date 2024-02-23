#AllenP5

.eqv PRINT_DBL 3
.eqv PRINT_INT 1
.eqv TERMINATE 10
.eqv ALLOC_MEM 9
.eqv PRINT_STR 4
.eqv NL	10
.eqv PRINT_CHAR 11


	.data
Arr1: .double 3.2, 8.6, 9.1, 15.2, -3.8, 21.8
Arr2: .double -3.5, 6.2, 18.0, 7.3, -5.3, 35.6

Space: .asciiz ", "
DisplayOne: .asciiz "The results of MaxArray(Registers): "
DisplayTwo: .asciiz "The results of MaxArray(Stack): "

	.text
main:
	#Determine arr size
	la $a0, Arr1
	move $t1, $a0			#temp storage for arr1
	la $a1, Arr2
	sub $a3, $a1, $a0		#subtract address of arr1 from arr2
	move $t2, $a3			#temp storage for array size
		
	#Determine element size
	srl $a3, $a3, 3
		
	#Allocate Heap memory for array 3
	move $a0, $t2
	li $v0, ALLOC_MEM
	syscall

	#Store Addresses
	move $a2, $v0			#store heap array address in $a2
	move $s0, $a2			#store heap array address for the PrintArray function
	move $a0, $t1			#restore $a0 with arr1 address

	#call MaxArray
	jal MaxArray

	#PrintDisplayOne
	la $a0, DisplayOne
	li $v0, PRINT_STR
	syscall
	
	#setup for PrintArray
	move $a0, $s0
	move $a1, $a3
		
	#call PrintArray
	jal PrintArray
	
	#print newline
	la $a0, NL
	li $v0, PRINT_CHAR
	syscall

#---(Optional_Code)------------------------------------------------------------------------------------------

	#PrintDisplayTwo
	la $a0, DisplayTwo
	li $v0, PRINT_STR
	syscall
	
	#setup for PrintArrayStack
	addi $sp, $sp, -8
	sw $s0, ($sp)
	sw $a1, 4($sp)
	
	#call PrintArrayStack
	jal PrintArrayStack
	
	#Deallocate memory from the heap
	addi $sp, $sp, 8
#----------------------------------------------------------------------------------------------------------------	
	
	#End Program
	li $v0, TERMINATE
	syscall

	
#----------------------------------------------------------------------------------------------------------------
#MaxArray- iterates between two arrays and places the larger element into a array stored in the heap
#Parameters:
#	$a0: Contains the address of Arr1
#	$a1: Contains the address of Arr2
#	$a2: Contains the address of Heap Array
#	$a3: Contains the number of elements in Array
#Return Value:
#	Function does not return anything
#Other Registers used:
#	$t0: Contains the loop counter
#	$f2: Contains the element from the first array
#	$f4: Contains the elsment from the second array
#----------------------------------------------------------------------------------------------------------------
MaxArray:
	li $t0, 0		#set loop counter to zero
MxArLoop:
	beq $t0, $a3, Done
	l.d $f2, ($a0)		#get element from arr1
	l.d $f4, ($a1)		#get element from arr2
	c.lt.d 3, $f2, $f4	#check arr1 < arr2
	
	bc1f 3, OneIsLarger	
	s.d $f4, ($a2)


Continue:	
	addi $a0, $a0, 8	#increment arr1 by one double
	addi $a1, $a1, 8	#increment arr2 by one double
	addi $a2, $a2, 8	#increment Heap Array by one double
	addi $t0, $t0, 1	#increment loop counter by one
	b MxArLoop

Done: 
	jr $ra
	
OneIsLarger:
	s.d $f2, ($a2)
	b Continue
	
#----------------------------------------------------------------------------------------------------------------	
#PrintArray- Display Heap Array contents from MaxArray
#Parameters:
#	$a0: Contains the address of Heap Array
#	$a1: Contains the number of elements in array
#Return Value:
#	Nothing is returned in PrintArray
#Other Registers Used:
#	$t0: Contains loop counter
#	$f12: Contains the double that is to be printed
#	$t1: Acts as the temporary storage for heap address when printing spaces
#	$v0: Used to call PRINT_DBL and PRINT_STR
#----------------------------------------------------------------------------------------------------------------

PrintArray:
	li $t0, 0		#set loop counter to zero
PrArLoop:
	beq $t0, $a1, Finish	
	l.d $f12 ($a0)		#load the element of the heap array
	move $t1, $a0
	li $v0, PRINT_DBL
	syscall
	la $a0, Space
	li $v0, PRINT_STR
	syscall
	addi $a0, $t1, 8	#increment heap array by a double
	addi $t0, $t0, 1	#increment loop counter by one
	j PrArLoop
	
Finish:
	jr $ra
	
#---(Optional_Code)----------------------------------------------------------------------------------------------	
#PrintArrayStack- Display Heap array contents with parameters passed by stack
#Parameters:
# 	($sp): Contains the address of heap stack
#	4($sp): Contains the number of elements 
#Return Value:
#	Nothing is returned in PrintArrayStack
#Other Registers Used:
#	$t0: Contains the loop counter
#	$t1: Contains the heap array address
#	$t2: Contains the number of array elements
#	$f12: Contains the double value in each element
#	$a0: Holds the string for spacing
#	$v0: Used to call PRINT_DBL and PRINT_STR
#----------------------------------------------------------------------------------------------------------------

PrintArrayStack:
	li $t0, 0		#set loop counter to zero
	lw $t1, ($sp)		#contains the address of the heap stack
	lw $t2, 4($sp)		#contains the number of elements in array
StackLoop:
	beq $t0, $t2, End
	l.d $f12, ($t1)		#load the element of the heap array
	li $v0, PRINT_DBL
	syscall
	la $a0, Space
	li $v0, PRINT_STR
	syscall
	addi $t1, $t1, 8	#increment heap array by a double 
	addi $t0, $t0, 1	#increment loop counter by one
	j StackLoop
End:
	jr $ra
#----------------------------------------------------------------------------------------------------------------	
	
	
	
	

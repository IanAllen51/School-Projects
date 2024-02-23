#AllenP7.asm


#constants
.eqv PRINT_INT 1
.eqv PRINT_STR 4
.eqv READ_INT 5
.eqv TERMINATE 10
.eqv NL 10
.eqv PRINT_CHAR 11

	.data
IntroStr: .asciiz "At each step, enter a positive integer or 0 to EXIT: \n"
Prompt: .asciiz "Integer? Zero to EXIT: "
Close: .asciiz "Done!"

	.text
main:
	
	#call ReverseList
	jal ReverseList
	
	#display closing prompt
	la $a0, Close
	li $v0, PRINT_STR
	syscall
	
	#end program
	li $v0 TERMINATE
	syscall

	
#------------------------------------------------------------------------------------------------------------------------------------------			
#ReverseList- Recursively calls for user to input numbers until 0 is input. The function will print inputs in reverse
#Parameters:
#	No parameters required for ReverseList.
#Return Values:
#	No values are returned by ReverseList.
#Other Registers Used:
#	$a0:	Used to store strings to display and will be used to temporarily hold the value loaded from the stack during recursion.
#	$a1:	Acts as the loop counter to determine if input of zero is the first input or the nth input
#	$sp:	Contains the return address of the previous recursion.
#	4($sp):	Contains the input value of the previous recursion.
#	$v0:	Used to display prompts and values. Also acts as a temporary storage for user input before transfer to a1.
#------------------------------------------------------------------------------------------------------------------------------------------	

ReverseList:
	la $a0, IntroStr		#display intro prompt
	li $v0, PRINT_STR
	syscall
	
	#li $a1, -1			#initialize loop counter

RunInput:
	#addi $a1, $a1, 1		#increment loop counter by 1
	la $a0, Prompt			#display prompt for user input
	li $v0, PRINT_STR
	syscall
	
	li $v0, READ_INT		#collect user input
	syscall
	
	move $t1, $v0			#store user input in t1
	bne $t1, $0, RunRvStr		#if input is other than zero, continue to run
	#bne $a1, $0, EndRecur		#if loop counter is greater than zero, there is input to display. branch to recursive return
	jr $ra				#return to main if user typed zero at first prompt
	
RunRvStr:
	addi $sp, $sp, -8		#allocate stack memory for two words
	sw $ra ($sp)			#store return address in first word of stackspace
	sw $t1 4($sp)			#store input in second word of stackspace
	
	jal RunInput			#recurse to user input
	
	lw $ra ($sp)			#load return address for next recursion
	lw $a0 4($sp)			#load value at current recursion
	li $v0, PRINT_INT		#display the current value on stack
	syscall
	
	li $a0, NL			#print new line
	li $v0, PRINT_CHAR
	syscall
	
	addi $sp, $sp, 8		#deallocate memory from stack
	jr $ra
	

EndRecur:
	#jr $ra				#if loop counter is greater than zero, return to address of RunInput in RunRvStr
	
#------------------------------------------------------------------------------------------------------------------------------------------	
	
	

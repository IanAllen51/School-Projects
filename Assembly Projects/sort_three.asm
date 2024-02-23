# sort_three.asm 
#
# This program calls a function that will sort its three input arguments from smallest to largest.
# Constants
.eqv PRINT_INT  1
.eqv PRINT_STR  4
.eqv TERMINATE  10

	.data
First:	.asciiz "Smallest value: "
Second:	.asciiz "\nMiddle value: "
Third:	.asciiz "\nLargest value: "

	.text
main:
	# Initialize the registers that are needed prior to calling SortThree
	li $a0, 5
	li $a1, 2
	li $a2, 4

	# Call the SortThree function
	jal SortThree

	# For each value, display the relevant prompt and the final value of the relevant register 
	move $t1, $a0
	lw $a0, First
	li $v0, PRINT_STR
	syscall

	move $a0, $t1
	li $v0, PRINT_STR
	syscall
	
	move $t1, $a1
	lw $a0, Second
	li $v0, PRINT_STR
	syscall

	move $a0, $t1
	li $v0, PRINT_STR
	syscall

	move $t1, $a2
	lw $a0, Third
	li $v0, PRINT_STR
	syscall

	move $a0, $t1
	li $v0, PRINT_STR
	syscall

	li $v0, TERMINATE	# terminate program
     	syscall


# SortThree - Sort the values in registers $a0, $a1, and $a2.

# Parameters:
#   Argument 1, in $a0
#   Argument 2, in $a1
#   Argument 3, in $a2

# Returns nothing.
#
# Comments: When the routine returns to the caller, the numbers in $a0, $a1, and $a2 
#   will be sorted from smallest to largest.
SortThree:
	# Compare $a0 and $a1, and swap if out of order
	ble $a0, $a1, Continue1	# Don't swap if they are in order
	# $a0 > $a1, so swap them
	move $t0, $a0
	move $a0, $a1
	move $a1, $t0
	
Continue1:
	# Compare $a0 and $a2, and swap if out of order
	ble $a0, $a2, Continue2	# Don't swap if they are in order
	# $a0 > $a2, so swap them
	move $t0, $a0
	move $a0, $a2
	move $a2, $t0
Continue2:
	# Compare $a1 and $a2, and swap if out of order
	ble $a1, $a2, Done		# Don't swap if they are in order
	# $a1 > $a2, so swap them
	move $t0, $a1
	move $a1, $a2
	move $a2, $t0
Done:	
	jr $ra			# return to main
	







 









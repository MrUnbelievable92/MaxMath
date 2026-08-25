.code

;__usf__udiv256x128
; rcx = dividend[0...63]		rdx = dividend[64...127]		r8 = dividend[128...191]		r9 = dividend[192...255]		[rsp + 40] = divisor.lo		[rsp + 48] = divisor.hi		[rsp + 56] = quoHi PTR
align 16
J proc public

	push		r15
	push		r14
	push		r13
	push		r12
	push		rsi
	push		rdi
	push		rbp
	push		rbx

	mov			rax, rcx
	mov			r14, qword ptr [rsp + 40 + (8 * 8) + 0]
	mov			r15, qword ptr [rsp + 40 + (8 * 8) + 8]
	bsr			rcx, r14
	mov			r10d, 127
	cmovne		r10, rcx
	xor			r10d, 63
	add			r10b, 64
	bsr			r11, r15
	xor			r11d, 63
	test		r15, r15
	movzx		ecx, r10b
	cmovne		ecx, r11d
	mov			r11, r14
	shl			r11, cl
	xor			r12d, r12d
	test		cl, 64
	mov			r10, r11
	cmovne		r10, r12
	mov			rsi, r15
	shld		rsi, r14, cl
	test		cl, 64
	cmovne		rsi, r11
	mov			r11, r8
	shl			r11, cl
	test		cl, 64
	mov			r13, r11
	cmovne		r13, r12
	shld		r9, r8, cl
	test		cl, 64
	cmovne		r9, r11
	mov			r8, rax
	shl			r8, cl
	test		cl, 64
	mov			rdi, r8
	cmovne		rdi, r12
	mov			rbx, rdx
	shld		rbx, rax, cl
	test		cl, 64
	cmovne		rbx, r8
	mov			r8, rdx
	shld		r8, rax, 63
	mov			r11, rdx
	shr			r11, 1
	xor			cl, 127
	shrd		r8, r11, cl
	shr			r11, cl
	test		cl, 64
	cmovne		r8, r11
	cmovne		r11, r12
	or			r11, r9
	or			r8, r13
	or			r14, r15
	cmove		rbx, r12
	cmove		rdi, r12
	cmove		r8, rax
	cmove		r11, rdx
	cmp			r11, rsi
	jae			UDIVREM128X64_0_DIVIDENDHI_GE_DIVISOR
	mov			rax, r8
	mov			rdx, r11
	div			rsi
	mov			rcx, rdx
	movq		xmm0, rax
	jmp			UDIVREM128X64_0_EXIT

UDIVREM128X64_0_DIVIDENDHI_GE_DIVISOR:
	mov			rax, r11
	xor			edx, edx
	div			rsi
	mov			r9, rax
	mov			rax, r8
	div			rsi
	mov			rcx, rdx
	movq		xmm0, rax
	movq		xmm1, r9
	punpcklqdq	xmm0, xmm1

UDIVREM128X64_0_EXIT:
	pshufd		xmm1, xmm0, 238
	movq		r15, xmm1
	movq		r14, xmm0
	xor			r9d, r9d
	mov			rax, r10
	mul			r14
	mov			r8, rax
	imul		r15, r10
	add			r15, rdx
	mov			rax, rbx
	movq		xmm2, r8
	sub			rax, r8
	mov			rdx, rcx
	sbb			rdx, r15
	setb		r11b
	mov			r12d, 0
	cmovb		r12, rsi
	mov			r13d, 0
	cmovb		r13, r10
	mov			rbp, rax
	neg			rbp
	mov			r8d, 0
	sbb			r8, rdx
	cmp			r10, rbp
	mov			rbp, rsi
	sbb			rbp, r8
	setb		bpl
	and			bpl, r11b
	add			r13, rax
	adc			r12, rdx
	test		bpl, bpl
	mov			edx, 0
	cmovne		rdx, rsi
	cmovne		r9, r10
	add			r9, r13
	adc			rdx, r12
	cmp			rdx, rsi
	jae			UDIVREM128X64_1_DIVIDENDHI_GE_DIVISOR
	mov			rax, r9
	div			rsi
	mov			r9, rdx
	movq		xmm0, rax
	jmp			UDIVREM128X64_1_EXIT

UDIVREM128X64_1_DIVIDENDHI_GE_DIVISOR:
	mov			rax, rdx
	xor			edx, edx
	div			rsi
	mov			r11, rax
	mov			rax, r9
	div			rsi
	mov			r9, rdx
	movq		xmm0, rax
	movq		xmm1, r11
	punpcklqdq	xmm0, xmm1

UDIVREM128X64_1_EXIT:
	movq		rax, xmm2
	cmp			rbx, rax
	sbb			rcx, r15
	sbb			r14, 0
	movzx		eax, bpl
	sub			r14, rax
	pshufd		xmm1, xmm0, 238
	movq		r8, xmm1
	movq		rcx, xmm0
	mov			rax, r10
	mul			rcx
	imul		r8, r10
	add			r8, rdx
	mov			rdx, rax
	sub			rdx, rdi
	mov			r11, r8
	sbb			r11, r9
	cmp			rdi, rax
	sbb			r9, r8
	setb		al
	cmp			r10, rdx
	sbb			rsi, r11
	setb		dl
	and			dl, al
	movzx		eax, al
	sub			rcx, rax
	movzx		eax, dl
	sub			rcx, rax

	mov			r12, qword ptr [rsp + 40 + (8 * 8) + 16]
	mov			qword ptr [r12], r14
	mov			rax, rcx

	pop			rbx
	pop			rbp
	pop			rdi
	pop			rsi
	pop			r12
	pop			r13
	pop			r14
	pop			r15

	ret

J endp

end









M_MAIN_UDIV_MAX_128x64_INC macro divisor

        mov         rax, -1
        xor         rdx, rdx
        div         divisor
        mov         r11, rax
        mov         rax, -1
        div         divisor
        add         rax, 1
        adc         r11, 0
    
endm

M_MAIN_UDIV_128hiXloRlo macro hi64, divisor

        mov         rdx, hi64
        xor         rax, rax 
        div         divisor
        mov         hi64, rax
    
endm

.code

;__spc__4xudivmax128x64_inc
;rcx: div0,      rdx: div2,     r8 result PTR       r9 div3,    [rsp + 40]: div4
align 16
v proc public

        mov         r10, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx
        
        mov         [r8], rax
        mov         [r8 + 8], r11

        add         r8, 16
        mov         rcx, r10
        mov         rdx, r9
        mov         r9, [rsp + 40]
    
;__spc__3xudivmax128x64_inc
;rcx: div0,      rdx: div2,     r8 result PTR       r9 div3
align 16
w proc public

        mov         r10, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx
        
        mov         [r8], rax
        mov         [r8 + 8], r11

        add         r8, 16
        mov         rcx, r10
        mov         rdx, r9
    
;__spc__2xudivmax128x64_inc
;rcx: div0,      rdx: div2,     r8 result PTR
align 16
x proc public

        mov         r9, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx
        
        mov         [r8], rax
        mov         [r8 + 8], r11
        
        M_MAIN_UDIV_MAX_128x64_INC r9

        mov         [r8 + 16], r11

        ret
    
x endp
w endp
v endp

;__spc__udivmax128x64_inc
;rcx: div0,      rdx: result hi PTR
align 16
y proc public

        mov         r8, rdx

        M_MAIN_UDIV_MAX_128x64_INC rcx

        mov         [r8], r11

        ret

y endp

;__spc__4xudiv128hiXloRlo
;rcx: left + result PTR,      rdx: div PTR
align 16
z proc public

        mov         r8, rdx
        
        M_MAIN_UDIV_128hiXloRlo [rcx], qword ptr [r8]

        add         rcx, 8
        mov         r9, [r8 + 8]
        mov         rdx, [r8 + 16]
        mov         r8, [r8 + 24]
    
;__spc__3xudiv128hiXloRlo
;rcx: left + result PTR,      rdx: div1,      r8: div2,      r9: div0
align 16
A proc public

        mov         r10, rdx

        M_MAIN_UDIV_128hiXloRlo [rcx], r9

        add         rcx, 8
        mov         rdx, r10
    
;__spc__2xudiv128hiXloRlo
;rcx: left + result PTR,      rdx: div0,      r8: div1
align 16
B proc public
 
        mov         r9, rdx
        
        M_MAIN_UDIV_128hiXloRlo [rcx], r9
        M_MAIN_UDIV_128hiXloRlo [rcx + 8], r8

        ret

B endp
A endp
z endp


end
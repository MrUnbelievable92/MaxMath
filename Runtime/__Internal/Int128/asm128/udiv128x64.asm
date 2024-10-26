M_DIVIDE macro instruction

        mov             rax, rcx
        instruction     r8

endm

M_UDIV_128x64 macro fulldiv

        xor         r10, r10
        cmp         r8, rdx
        
        mov         rax, rcx 
        mov         r11, rdx 
        cmovbe      rax, rdx 
        cmovbe      rdx, r10 
        div         r8
        cmp         r8, r11
if fulldiv
        cmovbe      r10, rax 
        mov         [r9], r10
endif
        ja          @f
        M_DIVIDE    div
@@:

endm

.code

;__udivrem128x64
;rcx: lo,   rdx: hi     r8: div     r9 qHi + rem64 PTR   r.hi = 0
align 16
m proc public

        M_UDIV_128x64 1

        mov          [r9 + 8], rdx

        ret

m endp

;__udivrem128x64_divLEhi
;rcx: lo,   rdx: hi     r8: div     r9 rem64 + quoHI PTR   r.hi = 0
align 16
n proc public
   
        mov         rax, rdx 
        xor         rdx, rdx 
        div         r8       
        mov         [r9 + 8], rax
    
;__usf__udivrem
;rcx: lo,   rdx: hi     r8: div     r9 rem ptr
align 16
D proc public

        M_DIVIDE    div
        mov         [r9], rdx

        ret
    
D endp
n endp

;__udiv128x64
;rcx: lo,   rdx: hi     r8: div     r9 qHi PTR     r.hi = 0
align 16
p proc public

        M_UDIV_128x64 1

@@:
        ret
    
p endp

;__udiv128x64_divLEhi
;rcx: lo,   rdx: hi     r8: div     r9 qHi PTR     r.hi = 0
align 16
q proc public

        mov         rax, rdx
        xor         rdx, rdx
        div         r8
        mov         [r9], rax
    
;__usf__udiv
;rcx: lo,   rdx: hi     r8: div
align 16
F proc public

        M_DIVIDE    div

        ret

F endp
q endp

;__urem128x64
;rcx: lo,   rdx: hi     r8: div     r.hi = 0
align 16
s proc public

        M_UDIV_128x64 0

        mov         rax, rdx

        ret
    
s endp

;__urem128x64_divLEhi
;rcx: lo,   rdx: hi     r8: div     r.hi = 0
align 16
t proc public

        mov         rax, rdx
        xor         rdx, rdx
        div         r8
    
;__usf__urem
;rcx: lo,   rdx: hi     r8: div
align 16
H proc public

        M_DIVIDE    div
        mov         rax, rdx

        ret

H endp
t endp


;__usf__idivrem
;rcx: lo,   rdx: hi     r8: div     r9 rem ptr
align 16
E proc public

        M_DIVIDE    idiv
        mov         [r9], rdx

        ret

E endp


;__usf__idiv
;rcx: lo,   rdx: hi     r8: div
align 16
G proc public

        M_DIVIDE    idiv

        ret

G endp


;__usf__irem
;rcx: lo,   rdx: hi     r8: div
align 16
I proc public

        M_DIVIDE    idiv
        mov         rax, rdx

        ret

I endp

end
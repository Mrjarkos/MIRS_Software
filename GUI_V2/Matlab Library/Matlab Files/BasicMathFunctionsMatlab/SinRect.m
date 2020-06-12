function [x, y] = SinRect(A, f, Offset, Ph, length)
T = 1/f;
x = 0:T/length:T;
w = 2*pi*f;
Ph = deg2rad(Ph);
y = A*abs(sin(w*x+Ph))+Offset;
end

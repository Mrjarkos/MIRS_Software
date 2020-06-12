function [x, y] = Sawtooth(A, f, Offset,Ph,duty, length)
T = 1/f;
x = 0:T/length:T;
w = 2*pi*f;
Ph = deg2rad(Ph);
duty = duty/100;
y = A*sawtooth(w*x+Ph, duty) + Offset;
end


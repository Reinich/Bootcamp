import cv2

img = cv2.imread('G:/Workplace/Bootcamp/Programming/Lection 14 OpenCV/test.jpg')
print(img)

#img = cv2.resize(img, (500, 500))
print(img.shape)

cv2.imshow('Result', img)
cv2.waitKey(0)
import cv2

cap = cv2.VideoCapture('G:/Workplace/Bootcamp/Programming/Lection 14 OpenCV/video.mp4')

while True:
    _, frame = cap.read()
    #cap = cv2.resize(cap, (500, 500))
    cv2.imshow('camera', frame)

    if cv2.waitKey(1) & 0xff == ord('q'):
        break

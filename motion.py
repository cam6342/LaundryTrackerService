#!/usr/bin/python
import RPi.GPIO as GPIO
import time


class Channel:
    def __init__(self,channelNumber,isHigh,numberOfStops):
        self.ChannelNumber = channelNumber
        self.IsHigh = isHigh
        self.NumberOfStops = numberOfStops
        

channel17 = Channel(17,False,0)
channel19 = Channel(19,False,0)

#GPIO SETUP
channelList = [channel17.ChannelNumber,channel19.ChannelNumber]
GPIO.setmode(GPIO.BCM)
GPIO.setup(channelList, GPIO.IN)


def callback17(channel):
    global channel17    
    channel17.IsHigh = True
    if(channel17.NumberOfStops > 0):
        channel17.NumberOfStops = 1
        
def callback19(channel):
    global channel19    
    channel19.IsHigh = True
    if(channel19.NumberOfStops > 0):
        channel19.NumberOfStops = 1
    

def MonitoringLoop(channel):    
    if(channel.IsHigh):
        if(channel.NumberOfStops == 0):
            print("Movement Detected! Channel: " + str(channel.ChannelNumber))
        if not(GPIO.input(channel.ChannelNumber)):
            print("Channel "+str(channel.ChannelNumber)+" stopped for: " + str(channel.NumberOfStops))
            channel.NumberOfStops = channel.NumberOfStops + 1
            if(channel.NumberOfStops == 60):
                channel.IsHigh = False
                print("Movement stopped! Channel: " + str(channel.ChannelNumber))
                channel.NumberOfStops = 0

GPIO.add_event_detect(channelList[0], GPIO.RISING, bouncetime=300)  # let us know when the pin goes HIGH or LOW
GPIO.add_event_detect(channelList[1], GPIO.RISING, bouncetime=300)  # let us know when the pin goes HIGH or LOW
GPIO.add_event_callback(channelList[0], callback17)  # assign function to GPIO PIN, Run function on change
GPIO.add_event_callback(channelList[1], callback19)  # assign function to GPIO PIN, Run function on change

# infinite loop
while True:
    MonitoringLoop(channel17)
    MonitoringLoop(channel19) 
    time.sleep(1)
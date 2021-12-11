#!/usr/bin/python

import requests
import json
import argparse
import os

parser=argparse.ArgumentParser()

parser.add_argument('--resource_group', help='Resource Group Name')
parser.add_argument('--service_name', help='Service Name of the APIM')
parser.add_argument('--apis', help='Apis Name')
parser.add_argument('--rtype', help='Type of the API (get,put,post etc)')
parser.add_argument('--operation', help='Operation Name')


args=parser.parse_args()

# resource_group = sys.argv[1]
# service_name = sys.argv[2]
# apis = sys.argv[3]
# rtype = sys.argv[4]
# operation = sys.argv[5]

def get_token():
    url = "https://login.microsoftonline.com/0c88fa98-b222-4fd8-9414-559fa424ce64/oauth2/token"

    payload = "grant_type=client_credentials\n&client_id=f7d4aa74-439d-4e5b-a1e3-aea0d83ac987\n&client_secret=sBIa.zKN.sXYInDbIE0xGdmWzMJNR36-QI\n&resource=https://management.azure.com/"
    headers = {
    'Content-Type': 'application/x-www-form-urlencoded',
    'Cookie': 'fpc=AqCn6b3Z_hZNnTiejPOxJ8arLvDZAQAAAPEiQNkOAAAA; stsservicecookie=estsfd; x-ms-gateway-slice=estsfd'
    }
    response = requests.request("POST", url, headers=headers, data=payload)
    return (str(json.loads(response.text)['access_token']))

def get_policy_from_xml():
    with open('./policy.xml','r') as file:
        policy = file.read()
    return(str(policy))


def get_for_if_match(resource_group , service_name):
    url = "https://management.azure.com/subscriptions/faab79a5-d424-4699-b3ff-b0cf94ea9f90/resourceGroups/"+ resource_group  +"/providers/Microsoft.ApiManagement/service/" + service_name + "?api-version=2020-12-01"
    payload={}
    headers = {
    'Authorization': 'Bearer ' + get_token()
    }
    response = requests.request("GET", url, headers=headers, data=payload)
    if response.status_code == 200:
        print("kakhagagha" + str(json.loads(response.content)['etag']))
        return ( json.loads(response.content)['etag'])
    else:
        print("Error generating Etag : for If match")
        

def put_for_policy_update(resource_group , service_name , apis , rtype ,  operation):
    url = "https://management.azure.com/subscriptions/faab79a5-d424-4699-b3ff-b0cf94ea9f90/resourceGroups/"+ resource_group +"/providers/Microsoft.ApiManagement/service/"+service_name+"/apis/"+apis+"/operations/"+rtype+"-"+operation+"/policies/policy?api-version=2021-08-01"
    payload = json.dumps({
    "properties": {
        "format": "xml",
        "value": get_policy_from_xml()
    }
    })
    headers = {
    'If-Match': str(get_for_if_match(resource_group , service_name )),
    'Authorization': 'Bearer ' + get_token(),
    'Content-Type': 'application/json'
    }
    response = requests.request("PUT", url, headers=headers, data=payload)
    print(response.text)

printf("PATH           ")
os.system("pwd")
put_for_policy_update(args.resource_group , args.service_name , args.apis , args.rtype ,  args.operation)


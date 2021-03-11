# Nutrient Diary

---

Design Document  

Romil Shah, Hardik Patel, Aruna Singh, Meera Nair  

## Introduction

Are you in the dilemma, that stuff you eating is it nutritious? Does the food you eat suffice your daily nutrition requirement? Nutrient Diary is here for you:  

- Take or upload pictures of food you willing to eat.
- Record the portion sizes you willing to eat.
- Get the nutrient info of the food based on the portion.

Use your web browser either on phone or desktop to get nutrient information. This helps you to stay Fit and Healthy .  

## Requirements

### Requirement 1: Identify the food

#### Scenario

As a user who's hungry or a nutritionist, can take a picture of food item or upload a picture of food item.

#### Dependencies
Food Items data are available and accessible.

#### Examples
1.1
Given a feed of food item data is available  

When I take a snap of "Apple"  

Then I should receive atleast one result with object as "Apple" with confidence greater than 0.8(threshhold)  

name: Apple  

score: 0.9  

### Requirement 2: Lookup for the Nutrients of Food

#### Scenario

Upon identifying the food item, we can lookup nutrition details.

#### Dependencies
Food Item's nutrition data are available and accessible.

#### Examples
2.1
Given a food item and nutrient data is available  

When a food item is detected  

We can lookup the nutrient data of food item  

Then I should receive the nutrient data of that food item with following details  

name: Iron, Fe  

amount: 0.53  

unitName: mg  

## Data Sources
[Google Cloud Vision API](https://cloud.google.com/vision)  

[Food Data Central](https://fdc.nal.usda.gov/)

## Team Composition
- Backend Developer: Romil Shah
- Frontend Developer: Hardik Patel
- Frontend Developer: Aruna Singh
- Business Analyst: Meera Nair

## Weekly Meeting
Saturday at 9 am in Lindner Hall  

Wednesday at 11 am on Teams

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceQuest : IQuest {

    private double disRequire;
    // Record current distance statistic when quest created
    private double disStart;
	private bool isDone = false;

    public DistanceQuest(string name, string description, 
        double disRequire) : base(name, description)
    {
        this.disRequire = disRequire;
		this.disStart = PlayerPrefs.GetFloat (DistanceQuestInput.PREV_DISTANCE, 0);
    }

	public override void Update(QuestInputData data)
	{
		double totalDistance = data.GetValue (DistanceQuestInput.INPUT_DISTANCE);
		if (totalDistance - disStart >= disRequire)
			isDone = true;
    }
	
    public override bool IsFinish()
    {
		return isDone;
    }
}
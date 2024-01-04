//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class FoodController : MonoBehaviour
{
    private GameObject audiosourceobject;
    private AudioSource audiosource;
    public int energychange = 10;
    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;
    private void Start()
    {
        audiosourceobject = GameObject.Find("munchin-95618-[AudioTrimmer.com]");
        audiosource = audiosourceobject.GetComponent<AudioSource>();
    }
    public void OnPointerClick()
    {
        EnergyHUDController.EnergyChange(energychange);
        audiosource.Play();
        this.gameObject.SetActive(false);
    }
}

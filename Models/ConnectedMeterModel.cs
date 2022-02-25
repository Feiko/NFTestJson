﻿using System;


namespace NFTestTreading.Models
{
    public class ConnectedMeterModel
    {
        /// <summary>
        /// Channel to which the meter device is attached and is broadcasting on
        /// </summary>
        public uint Channel { get;  set; }

        /// <summary>
        /// 0-n:24.1.0.255 - Device-Type
        /// </summary>
        public uint DeviceType { get;  set; }

        /// <summary>
        /// 0-n:96.1.0.255 - Equipment identifier
        /// </summary>
        public string DeviceId { get;  set; }

        /// <summary>
        /// 0-n:24.2.1.255 - Date-time stamp of the P1 message (usual every 5 minutes)
        /// </summary>
        public DateTime DeviceTimeStamp { get;  set; }

        /// <summary>
        /// 0-n:24.2.1.255 - Value measured
        /// </summary>
        public double DeviceValue { get;  set; }

        /// <summary>
        /// Measurement Unit of measured value
        /// </summary>
        public string DeviceMeasurementUnit { get;  set; }
    }
}

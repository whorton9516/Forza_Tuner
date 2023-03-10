

namespace Forza_Tuner.UDPConnection
{
    public class TelemetryData
    {

        // Sled
        public bool IsRaceOn { get; set; }
        public uint TimestampMS { get; set; } // NOTE: will overflow to 0 eventually
        public float EngineMaxRpm { get; set; }
        public float EngineIdleRpm { get; set; }
        public float CurrentEngineRpm { get; set; }

        // X = right, Y = up, Z = forward
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }
        public float AccelerationZ { get; set; }

        // X = right, Y = up, Z = forward
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float VelocityZ { get; set; }

        // For the Car; X = pitch, Y = yaw, Z = roll
        public float AngularVelocityX { get; set; }
        public float AngularVelocityY { get; set; }
        public float AngularVelocityZ { get; set; }

        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }

        // Suspension travel normalized: 0.0f = max stretch; 1.0 = max compression
        public float NormalizedSuspensionTravelFrontLeft { get; set; }
        public float NormalizedSuspensionTravelFrontRight { get; set; }
        public float NormalizedSuspensionTravelRearLeft { get; set; }
        public float NormalizedSuspensionTravelRearRight { get; set; }

        // Slip ratio of the tires (Normalized); 0 means 100% grip and |ratio| > 1.0 means loss of grip.
        public float TireSlipRatioFrontLeft { get; set; }
        public float TireSlipRatioFrontRight { get; set; }
        public float TireSlipRatioRearLeft { get; set; }
        public float TireSlipRatioRearRight { get; set; }

        // Wheel rotation speed radians/sec.
        public float WheelRotationSpeedFrontLeft { get; set; }
        public float WheelRotationSpeedFrontRight { get; set; }
        public float WheelRotationSpeedRearLeft { get; set; }
        public float WheelRotationSpeedRearRight { get; set; }

        // = 1 when wheel is on rumble strip, = 0 when off.
        public float WheelOnRumbleStripFrontLeft { get; set; }
        public float WheelOnRumbleStripFrontRight { get; set; }
        public float WheelOnRumbleStripRearLeft { get; set; }
        public float WheelOnRumbleStripRearRight { get; set; }

        // = from 0 to 1, where 1 is the deepest puddle
        public float WheelInPuddleDepthFrontLeft { get; set; }
        public float WheelInPuddleDepthFrontRight { get; set; }
        public float WheelInPuddleDepthRearLeft { get; set; }
        public float WheelInPuddleDepthRearRight { get; set; }

        // Non-dimensional surface rumble values passed to controller force feedback
        public float SurfaceRumbleFrontLeft { get; set; }
        public float SurfaceRumbleFrontRight { get; set; }
        public float SurfaceRumbleRearLeft { get; set; }
        public float SurfaceRumbleRearRight { get; set; }

        // Tire normalized slip angle, = 0 means 100% grip and |angle| > 1.0 means loss of grip.
        public float TireSlipAngleFrontLeft { get; set; }
        public float TireSlipAngleFrontRight { get; set; }
        public float TireSlipAngleRearLeft { get; set; }
        public float TireSlipAngleRearRight { get; set; }

        // Tire normalized combined slip, = 0 means 100% grip and |slip| > 1.0 means loss of grip.
        public float TireCombinedSlipFrontLeft { get; set; }
        public float TireCombinedSlipFrontRight { get; set; }
        public float TireCombinedSlipRearLeft { get; set; }
        public float TireCombinedSlipRearRight { get; set; }

        // Actual suspension travel in meters
        public float SuspensionTravelMetersFrontLeft { get; set; }
        public float SuspensionTravelMetersFrontRight { get; set; }
        public float SuspensionTravelMetersRearLeft { get; set; }
        public float SuspensionTravelMetersRearRight { get; set; }

        public uint CarClass { get; set; }             // Between 0 (D -- worst cars) and 7 (X class -- best cars) inclusive
        public uint CarPerformanceIndex { get; set; }  // Between 100 (slowest car) and 999 (fastest car) inclusive
        public uint DrivetrainType { get; set; }       // Corresponds to EDrivetrainType; 0 = FWD, 1 = RWD, 2 = AWD
        public uint NumCylinders { get; set; }         // Number of cylinders in the engine
        public uint CarType { get; set; }               // Car Classification
        public uint CarOrdinal { get; set; }           // Unique ID of the car make/model


        // Dash
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }

        // Engine Output
        public float Speed { get; set; }
        public float Power { get; set; }
        public float Torque { get; set; }

        // Tire Temperature in Celcius
        public float TireTempFrontLeft { get; set; }
        public float TireTempFrontRight { get; set; }
        public float TireTempRearLeft { get; set; }
        public float TireTempRearRight { get; set; }

        public float Boost { get; set; }
        public float Fuel { get; set; }
        public float Distance { get; set; }
        public float BestLapTime { get; set; }
        public float LastLapTime { get; set; }
        public float CurrentLapTime { get; set; }
        public float CurrentRaceTime { get; set; }
        public uint Lap { get; set; }
        public uint RacePosition { get; set; }

        // Pedal engagement
        public uint Accelerator { get; set; }
        public uint Brake { get; set; }
        public uint Clutch { get; set; }

        public uint Handbrake { get; set; }
        public uint Gear { get; set; }
        public int Steer { get; set; }
        public uint NormalDrivingLine { get; set; }
        public uint NormalAiBrakeDifference { get; set; }
    }
}
